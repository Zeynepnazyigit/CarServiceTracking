using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace CarServiceTracking.API.Middlewares
{
    /// <summary>
    /// Katmanlı mimari: API katmanında tüm istisnaları yakalar,
    /// veritabanı hatalarını (DbUpdateException) anlamlı mesaja çevirir.
    /// </summary>
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly IHostEnvironment _environment;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger, IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);
                if (ex is DbUpdateException dbEx && dbEx.InnerException != null)
                    _logger.LogError(dbEx.InnerException, "Inner exception (veritabanı): {Message}", dbEx.InnerException.Message);
                await HandleExceptionAsync(context, ex, _environment.IsDevelopment());
            }
        }

        private static string GetUserFriendlyMessage(Exception exception)
        {
            var innerMessage = exception.InnerException?.Message ?? exception.Message;

            if (innerMessage.Contains("IX_Invoices_ServiceRequestId", StringComparison.OrdinalIgnoreCase) ||
                innerMessage.Contains("UNIQUE", StringComparison.OrdinalIgnoreCase) && innerMessage.Contains("ServiceRequestId", StringComparison.OrdinalIgnoreCase))
                return "Bu servis talebi için zaten bir fatura mevcut.";

            if (innerMessage.Contains("IX_Invoices_InvoiceNumber", StringComparison.OrdinalIgnoreCase))
                return "Fatura numarası çakışması oluştu. Lütfen tekrar deneyin.";

            if (innerMessage.Contains("FK_", StringComparison.OrdinalIgnoreCase) || innerMessage.Contains("foreign key", StringComparison.OrdinalIgnoreCase))
                return "İlişkili kayıt bulunamadı. Lütfen müşteri ve servis talebinin geçerli olduğundan emin olun.";

            return "Bir hata oluştu. Lütfen daha sonra tekrar deneyin.";
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, bool isDevelopment)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var isDbUpdate = exception is DbUpdateException;
            var message = isDbUpdate ? GetUserFriendlyMessage(exception) : "Bir hata oluştu. Lütfen daha sonra tekrar deneyin.";
            var innerDetail = isDbUpdate ? (exception.InnerException?.Message ?? exception.Message) : exception.Message;

            var response = new
            {
                success = false,
                message,
                detail = isDevelopment ? innerDetail : null,
                data = (object?)null
            };

            var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return context.Response.WriteAsync(jsonResponse);
        }
    }
}

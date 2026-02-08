using System.Net;

namespace CarServiceTracking.UI.Web.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            
            // Development'da detaylı hata göster
            var message = _env.IsDevelopment() 
                ? $"{exception.Message} | {exception.StackTrace}" 
                : "Bir hata oluştu. Lütfen daha sonra tekrar deneyin.";
            
            context.Response.Redirect($"/Error?message={Uri.EscapeDataString(message)}");
            return Task.CompletedTask;
        }
    }
}

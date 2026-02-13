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
            // Özel durum: API'den gelen 401 Unauthorized (örneğin JWT süresi dolmuş ya da token yok)
            if (exception is HttpRequestException httpRequestException)
            {
                var isUnauthorized =
                    httpRequestException.StatusCode == HttpStatusCode.Unauthorized ||
                    (httpRequestException.Message?.Contains("401 (Unauthorized)", StringComparison.OrdinalIgnoreCase) ?? false);

                if (isUnauthorized)
                {
                    _logger.LogWarning(exception,
                        "API isteği 401 Unauthorized döndürdü. Kullanıcı login sayfasına yönlendiriliyor.");

                    var returnUrl = context.Request.Path + context.Request.QueryString;

                    var loginUrl = string.IsNullOrEmpty(returnUrl)
                        ? "/Auth/Login"
                        : $"/Auth/Login?returnUrl={Uri.EscapeDataString(returnUrl)}";

                    context.Response.Redirect(loginUrl);
                    return Task.CompletedTask;
                }
            }

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

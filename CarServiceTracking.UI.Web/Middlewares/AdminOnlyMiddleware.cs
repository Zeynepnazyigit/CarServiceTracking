using CarServiceTracking.UI.Web.Infrastructure;

namespace CarServiceTracking.UI.Web.Middlewares
{
    public class AdminOnlyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AdminOnlyMiddleware> _logger;

        public AdminOnlyMiddleware(RequestDelegate next, ILogger<AdminOnlyMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Session'dan role oku
            var userRole = context.Session.GetString("UserRole");
            var token = context.Session.GetString("access_token");

            _logger.LogInformation("AdminOnlyMiddleware - UserRole: {Role}, Token: {HasToken}", 
                userRole ?? "null", 
                !string.IsNullOrEmpty(token) ? "YES" : "NO");

            // Session boşsa token'dan role okumayı dene
            if (string.IsNullOrEmpty(userRole) && !string.IsNullOrEmpty(token))
            {
                userRole = JwtTokenHelper.GetRoleFromToken(token);
                
                // Role bulunduysa session'a kaydet
                if (!string.IsNullOrEmpty(userRole))
                {
                    context.Session.SetString("UserRole", userRole);
                }
            }

            // Admin değilse login'e yönlendir
            if (userRole != "Admin")
            {
                _logger.LogWarning("Unauthorized access attempt to Admin area. UserRole: {Role}", userRole ?? "null");
                context.Response.Redirect("/Auth/Login");
                return;
            }

            // Admin ise devam et
            await _next(context);
        }
    }
}

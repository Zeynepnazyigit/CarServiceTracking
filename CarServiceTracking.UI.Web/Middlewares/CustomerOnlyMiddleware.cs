using CarServiceTracking.UI.Web.Infrastructure;

namespace CarServiceTracking.UI.Web.Middlewares
{
    public class CustomerOnlyMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomerOnlyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Session'dan role oku
            var userRole = context.Session.GetString("UserRole");

            // Session boşsa token'dan role okumayı dene
            if (string.IsNullOrEmpty(userRole))
            {
                var token = context.Session.GetString("access_token");
                
                if (!string.IsNullOrEmpty(token))
                {
                    userRole = JwtTokenHelper.GetRoleFromToken(token);
                    
                    // Role bulunduysa session'a kaydet
                    if (!string.IsNullOrEmpty(userRole))
                    {
                        context.Session.SetString("UserRole", userRole);
                    }
                }
            }

            // Customer değilse login'e yönlendir
            if (userRole != "Customer")
            {
                context.Response.Redirect("/Auth/Login");
                return;
            }

            // Customer ise devam et
            await _next(context);
        }
    }
}

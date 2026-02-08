using System.Net.Http.Headers;

namespace CarServiceTracking.UI.Web.Infrastructure
{
    public class JwtTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<JwtTokenHandler> _logger;

        public JwtTokenHandler(IHttpContextAccessor httpContextAccessor, ILogger<JwtTokenHandler> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // Session'dan token oku
            var token = _httpContextAccessor.HttpContext?.Session.GetString("access_token");

            _logger.LogInformation("🔐 JwtTokenHandler - Request: {Method} {Url}", 
                request.Method, 
                request.RequestUri?.PathAndQuery);
            
            _logger.LogInformation("🔐 Token from session: {HasToken}, Length: {Length}", 
                !string.IsNullOrEmpty(token) ? "YES" : "NO", 
                token?.Length ?? 0);

            // Token varsa Authorization header'ına ekle
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                _logger.LogInformation("✅ Authorization header added");
            }
            else
            {
                _logger.LogWarning("⚠️ NO TOKEN - Request will be sent WITHOUT Authorization header!");
            }

            // Request'i devam ettir
            var response = await base.SendAsync(request, cancellationToken);
            
            _logger.LogInformation("📥 Response: {StatusCode}", response.StatusCode);
            
            return response;
        }
    }
}

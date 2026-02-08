using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CarServiceTracking.UI.Web.Infrastructure
{
    public static class JwtTokenHelper
    {
        public static string? GetRoleFromToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                
                // Token parse edilebilir mi kontrol et
                if (!handler.CanReadToken(token))
                    return null;

                var jwtToken = handler.ReadJwtToken(token);

                // Role claim'ini oku
                var roleClaim = jwtToken.Claims.FirstOrDefault(c => 
                    c.Type == ClaimTypes.Role || 
                    c.Type == "role" || 
                    c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");

                return roleClaim?.Value;
            }
            catch
            {
                return null;
            }
        }
    }
}

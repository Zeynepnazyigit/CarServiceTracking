using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using CarServiceTracking.Core.Entities;

namespace CarServiceTracking.Business.Services
{
    /// <summary>
    /// JWT token generation ve validation servisi
    /// </summary>
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
        string GenerateToken(int userId, string email, string role);
        ClaimsPrincipal? ValidateToken(string token);
    }

    public class JwtTokenService : IJwtTokenService
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expireMinutes;

        public JwtTokenService(IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");
            _key = jwtSettings["Key"] ?? throw new InvalidOperationException("Jwt:Key is not configured");
            _issuer = jwtSettings["Issuer"] ?? throw new InvalidOperationException("Jwt:Issuer is not configured");
            _audience = jwtSettings["Audience"] ?? throw new InvalidOperationException("Jwt:Audience is not configured");
            _expireMinutes = int.Parse(jwtSettings["ExpireMinutes"] ?? "1440");
        }

        /// <summary>
        /// Verilen User'dan JWT token üret
        /// </summary>
        public string GenerateToken(User user)
        {
            return GenerateToken(user.Id, user.Email, user.Role);
        }

        /// <summary>
        /// Verilen parametrelerden JWT token üret
        /// </summary>
        public string GenerateToken(int userId, string email, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_key);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_expireMinutes),
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Token'ı validate et ve ClaimsPrincipal dön
        /// </summary>
        public ClaimsPrincipal? ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_key);

                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _issuer,
                    ValidateAudience = true,
                    ValidAudience = _audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}

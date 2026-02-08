using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Business.Services;
using CarServiceTracking.Core.DTOs;
using CarServiceTracking.Core.DTOs.CustomerDTOs;

namespace CarServiceTracking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ICustomerAuthService _customerAuthService;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            ICustomerAuthService customerAuthService,
            IJwtTokenService jwtTokenService,
            ILogger<AuthController> logger)
        {
            _customerAuthService = customerAuthService;
            _jwtTokenService = jwtTokenService;
            _logger = logger;
        }

        /// <summary>
        /// User login - JWT token dön
        /// </summary>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse<LoginResponseDTO>>> Login([FromBody] CustomerLoginDTO dto)
        {
            _logger.LogWarning("🔍 LOGIN ATTEMPT - Email: {Email}", dto.Email);
            
            // Giriş işlemi
            var result = await _customerAuthService.LoginAsync(dto);
            
            _logger.LogWarning("🔍 LOGIN RESULT - Success: {Success}, Role: {Role}, UserId: {UserId}", 
                result.Success, 
                result.Success ? result.Data.Role : "N/A",
                result.Success ? result.Data.UserId : -1);

            // Başarılı giriş
            if (result.Success)
            {
                // Token oluştur (role bilgisini result.Data'dan al)
                var token = _jwtTokenService.GenerateToken(
                    result.Data.UserId,
                    result.Data.Email,
                    result.Data.Role);

                var response = new LoginResponseDTO
                {
                    UserId = result.Data.UserId,
                    Email = result.Data.Email,
                    Role = result.Data.Role,
                    Token = token,
                    ExpiresAt = DateTime.UtcNow.AddHours(24)
                };
                
                _logger.LogWarning("🔍 RESPONSE CREATED - Role: {Role}, UserId: {UserId}", response.Role, response.UserId);

                return Ok(ApiResponse<LoginResponseDTO>.SuccessResponse(
                    response,
                    "Giriş başarılı"));
            }

            // Hatalı giriş
            return Unauthorized(ApiResponse<LoginResponseDTO>.ErrorResponse(
                result.Message,
                result.Message));
        }

        /// <summary>
        /// Yeni müşteri kaydı
        /// </summary>
        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse<object>>> Signup([FromBody] CustomerSignupDTO dto)
        {
            var result = await _customerAuthService.SignupAsync(dto);

            if (result.Success)
                return Ok(ApiResponse<object>.SuccessResponse(null, result.Message));

            return BadRequest(ApiResponse<object>.ErrorResponse(result.Message, result.Message));
        }

        /// <summary>
        /// Token'ı validate et - debug için
        /// </summary>
        [HttpPost("validate")]
        [Authorize]
        public IActionResult ValidateToken()
        {
            var userId = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var email = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            var role = User.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;

            return Ok(ApiResponse<object>.SuccessResponse(
                new { userId, email, role },
                "Token geçerli"));
        }
    }

    /// <summary>
    /// Login cevap DTO - JWT token ile
    /// </summary>
    public class LoginResponseDTO
    {
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}

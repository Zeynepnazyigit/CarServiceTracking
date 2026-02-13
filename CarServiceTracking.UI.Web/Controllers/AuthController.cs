using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.Constants;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthApiService _authApiService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AuthApiService authApiService, ILogger<AuthController> logger)
        {
            _authApiService = authApiService;
            _logger = logger;
        }

        // =========================
        // LOGIN - GET
        // =========================
        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Auth/Login.cshtml");
        }

        // =========================
        // LOGIN - POST
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            _logger.LogInformation("Login attempt for email: {Email}", email);

            var loginResponse = await _authApiService.LoginAsync(email, password);

            _logger.LogInformation("Login response received. IsNull: {IsNull}, Token: {HasToken}",
                loginResponse == null,
                loginResponse?.Token != null ? "YES" : "NO");

            if (loginResponse != null)
            {
                HttpContext.Session.SetString("UserRole", loginResponse.Role);
                HttpContext.Session.SetInt32("UserId", loginResponse.UserId);

                if (loginResponse.CustomerId.HasValue)
                    HttpContext.Session.SetInt32("CustomerId", loginResponse.CustomerId.Value);

                // JWT token'ı tüm API çağrılarında kullanılacak ortak key ile sakla
                HttpContext.Session.SetString("access_token", loginResponse.Token);

                _logger.LogInformation(
                    "Session set - Role: {Role}, UserId: {UserId}, Token length: {TokenLength}",
                    loginResponse.Role,
                    loginResponse.UserId,
                    loginResponse.Token?.Length ?? 0);

                if (loginResponse.Role == Roles.Admin)
                {
                    return RedirectToAction("Index", "AdminDashboard");
                }
                else if (loginResponse.Role == Roles.Customer)
                {
                    return RedirectToAction("Index", "CustomerHome");
                }
            }

            ViewBag.Error = "E-posta veya şifre hatalı";
            return View("~/Views/Auth/Login.cshtml");
        }

        // =========================
        // LOGOUT
        // =========================
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // =========================
        // REGISTER - POST
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(
            string firstName,
            string lastName,
            string email,
            string password,
            string phone)
        {
            var (success, message) =
                await _authApiService.SignupAsync(firstName, lastName, email, password, phone);

            if (success)
            {
                TempData["Success"] = message;
                return RedirectToAction("Login");
            }

            ViewBag.RegisterError = message;
            return View("~/Views/Auth/Login.cshtml");
        }
    }
}
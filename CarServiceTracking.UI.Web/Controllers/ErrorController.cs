using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        public IActionResult Index(string? message)
        {
            ViewBag.ErrorMessage = message ?? "Beklenmeyen bir hata oluştu.";
            return View();
        }
    }
}

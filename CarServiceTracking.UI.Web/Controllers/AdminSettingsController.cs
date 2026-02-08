using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminSettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Home sayfasýna girince direkt Cars listesine atsýn
            return RedirectToAction("Index", "Cars");
        }
    }
}

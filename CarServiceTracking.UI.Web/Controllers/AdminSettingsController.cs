using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminSettingsController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

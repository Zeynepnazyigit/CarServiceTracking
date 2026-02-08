using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminDashboardController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

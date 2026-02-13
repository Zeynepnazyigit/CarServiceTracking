using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminRentalsController : AdminBaseController
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "AdminRentalAgreements");
        }
    }
}

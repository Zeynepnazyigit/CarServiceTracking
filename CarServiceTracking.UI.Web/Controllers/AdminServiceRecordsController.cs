using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminServiceRecordsController : AdminBaseController
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "AdminServiceRequests");
        }
    }
}

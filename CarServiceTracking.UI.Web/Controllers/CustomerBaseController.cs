using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarServiceTracking.UI.Web.Controllers
{
    public abstract class CustomerBaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var role = HttpContext.Session.GetString("UserRole");
            var userId = HttpContext.Session.GetInt32("UserId");

            if (role != "Customer" || userId == null)
            {
                context.Result = new RedirectToActionResult(
                    "Login",
                    "Auth",
                    null
                );
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}

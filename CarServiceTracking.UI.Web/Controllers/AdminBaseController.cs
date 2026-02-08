using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarServiceTracking.UI.Web.Controllers
{
    public abstract class AdminBaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var role = HttpContext.Session.GetString("UserRole");

            if (role != "Admin")
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

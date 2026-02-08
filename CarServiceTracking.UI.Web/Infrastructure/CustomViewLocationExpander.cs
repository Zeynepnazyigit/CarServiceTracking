using Microsoft.AspNetCore.Mvc.Razor;

namespace CarServiceTracking.UI.Web.Infrastructure
{
    public class CustomViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // Controller adına göre klasör belirle
            var controllerName = context.ControllerName;

            if (controllerName.StartsWith("Admin"))
            {
                context.Values["folder"] = "Admin";
            }
            else if (controllerName.StartsWith("Customer"))
            {
                context.Values["folder"] = "Customer";
            }
            else
            {
                context.Values["folder"] = "";
            }
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (!context.Values.TryGetValue("folder", out var folder))
            {
                folder = "";
            }

            var controllerName = context.ControllerName;
            var viewName = context.ViewName;

            var paths = new List<string>();

            // Admin ve Customer klasörleri
            if (!string.IsNullOrEmpty(folder))
            {
                // Special mapping: CustomerHome → Home
                string folderName = controllerName;
                if (controllerName == "CustomerHome")
                    folderName = "Home";
                else if (controllerName == "AdminDashboard")
                    folderName = "Dashboard";

                paths.Add($"/Views/{folder}/{folderName}/{viewName}.cshtml");
                paths.Add($"/Views/{folder}/Shared/{viewName}.cshtml");
            }

            // Root Shared
            paths.Add($"/Views/Shared/{viewName}.cshtml");

            return paths;
        }
    }
}

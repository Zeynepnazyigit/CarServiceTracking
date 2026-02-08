using Microsoft.AspNetCore.Authorization;
using RoleConstants = CarServiceTracking.Core.Constants.Roles;

namespace CarServiceTracking.API.Authorization
{
    /// <summary>
    /// Admin rolü gerekli - [AdminOnly] kullan
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminOnlyAttribute : AuthorizeAttribute
    {
        public AdminOnlyAttribute()
        {
            Roles = RoleConstants.Admin;
        }
    }

    /// <summary>
    /// Customer rolü gerekli - [CustomerOnly] kullan
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomerOnlyAttribute : AuthorizeAttribute
    {
        public CustomerOnlyAttribute()
        {
            Roles = RoleConstants.Customer;
        }
    }

    /// <summary>
    /// Admin veya Customer - [UserOnly] kullan
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UserOnlyAttribute : AuthorizeAttribute
    {
        public UserOnlyAttribute()
        {
            Roles = RoleConstants.AdminOrCustomer;
        }
    }
}

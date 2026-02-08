using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.Models.ApiModels.CustomerApiModels
{
    public class CustomerLoginApiModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}

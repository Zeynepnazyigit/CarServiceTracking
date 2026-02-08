using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.Models.ApiModels.CustomerApiModels
{
    public class CustomerSignupApiModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;
    }
}

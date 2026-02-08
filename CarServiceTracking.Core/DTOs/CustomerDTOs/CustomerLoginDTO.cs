using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.Core.DTOs.CustomerDTOs
{
    public class CustomerLoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}

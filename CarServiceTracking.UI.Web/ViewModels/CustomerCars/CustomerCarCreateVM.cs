using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.CustomerCars
{
    public class CustomerCarCreateVM
    {
        public int CustomerId { get; set; }
           
        [Required(ErrorMessage = "Marka/Model zorunludur")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Marka/Model 3-200 karakter olmalı")]
        public string BrandModel { get; set; } = null!;

        [Required(ErrorMessage = "Plaka zorunludur")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Plaka 5-20 karakter olmalı")]
        public string PlateNumber { get; set; } = null!;

        [Range(1900, 2100, ErrorMessage = "Yıl 1900-2100 arasında olmalı")]
        public int Year { get; set; }

        [Range(0, 9999999, ErrorMessage = "Kilometre geçerli olmalı")]
        public int Mileage { get; set; }

        [StringLength(50, ErrorMessage = "Renk maksimum 50 karakter")]
        public string? Color { get; set; }

        public bool IsInService { get; set; }
    }
}

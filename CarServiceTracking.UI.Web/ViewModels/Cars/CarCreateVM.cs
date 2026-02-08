using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.Cars
{
    public class CarCreateVM
    {
        [Required(ErrorMessage = "Plaka zorunludur")]
        [StringLength(20, ErrorMessage = "Plaka en fazla 20 karakter olabilir")]
        public string PlateNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Marka zorunludur")]
        [StringLength(50, ErrorMessage = "Marka en fazla 50 karakter olabilir")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model zorunludur")]
        [StringLength(50, ErrorMessage = "Model en fazla 50 karakter olabilir")]
        [Display(Name = "Model")]
        public string CarModel { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yıl zorunludur")]
        [Range(1900, 2100, ErrorMessage = "Geçerli bir yıl giriniz")]
        public int Year { get; set; }

        [StringLength(30)]
        public string? Color { get; set; }

        [StringLength(50)]
        public string? ChassisNumber { get; set; }

        [Range(0, 999999)]
        public int? Mileage { get; set; }

        [StringLength(50)]
        public string? EngineNumber { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "Müşteri seçimi zorunludur")]
        public int CustomerId { get; set; }

        public int? FuelTypeId { get; set; }
        public int? TransmissionTypeId { get; set; }
        public int? CarTypeId { get; set; }
    }
}

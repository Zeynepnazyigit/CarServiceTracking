using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.Rentals
{
    public class RentalVehicleCreateVM
    {
        [Required(ErrorMessage = "Plaka zorunludur")]
        [StringLength(20, ErrorMessage = "Plaka en fazla 20 karakter olabilir")]
        public string PlateNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Marka zorunludur")]
        [StringLength(100, ErrorMessage = "Marka en fazla 100 karakter olabilir")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model zorunludur")]
        [StringLength(100, ErrorMessage = "Model en fazla 100 karakter olabilir")]
        public string Model { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yıl zorunludur")]
        [Range(1900, 2100, ErrorMessage = "Geçerli bir yıl giriniz")]
        public int Year { get; set; } = DateTime.Now.Year;

        [Required(ErrorMessage = "Yakıt tipi zorunludur")]
        [StringLength(50)]
        public string FuelType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vites tipi zorunludur")]
        [StringLength(50)]
        public string TransmissionType { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Renk en fazla 50 karakter olabilir")]
        public string? Color { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Kilometre 0 veya daha büyük olmalıdır")]
        public int? Mileage { get; set; }

        [Required(ErrorMessage = "Günlük ücret zorunludur")]
        [Range(0.01, 999999.99, ErrorMessage = "Günlük ücret 0.01 ile 999999.99 arasında olmalıdır")]
        public decimal DailyRate { get; set; }

        public bool IsAvailable { get; set; } = true;

        [StringLength(500)]
        public string? Features { get; set; }
    }
}

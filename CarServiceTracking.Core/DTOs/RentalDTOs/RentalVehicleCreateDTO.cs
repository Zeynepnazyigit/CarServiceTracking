using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.Core.DTOs.RentalDTOs
{
    public class RentalVehicleCreateDTO
    {
        [Required(ErrorMessage = "Plaka alanı zorunludur.")]
        [MaxLength(15, ErrorMessage = "Plaka en fazla 15 karakter olabilir.")]
        public string PlateNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Marka alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "Marka en fazla 50 karakter olabilir.")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "Model en fazla 50 karakter olabilir.")]
        public string Model { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yıl alanı zorunludur.")]
        [Range(1950, 2030, ErrorMessage = "Yıl 1950-2030 arasında olmalıdır.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Renk alanı zorunludur.")]
        [MaxLength(30, ErrorMessage = "Renk en fazla 30 karakter olabilir.")]
        public string Color { get; set; } = string.Empty;

        [Required(ErrorMessage = "Günlük ücret zorunludur.")]
        [Range(1, 99999, ErrorMessage = "Günlük ücret 1-99999 arasında olmalıdır.")]
        public decimal DailyRate { get; set; }

        public bool IsAvailable { get; set; } = true;

        [Range(0, 2000000, ErrorMessage = "Kilometre 0-2.000.000 arasında olmalıdır.")]
        public int Mileage { get; set; }

        [MaxLength(30, ErrorMessage = "Yakıt tipi en fazla 30 karakter olabilir.")]
        public string? FuelType { get; set; }

        [MaxLength(30, ErrorMessage = "Vites tipi en fazla 30 karakter olabilir.")]
        public string? TransmissionType { get; set; }

        [MaxLength(500, ErrorMessage = "Not en fazla 500 karakter olabilir.")]
        public string? Notes { get; set; }
    }
}

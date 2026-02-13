using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.Core.DTOs.CarDTOs
{
    public class CarCreateDTO
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

        [MaxLength(30, ErrorMessage = "Renk en fazla 30 karakter olabilir.")]
        public string? Color { get; set; }

        [MaxLength(20, ErrorMessage = "Şasi numarası en fazla 20 karakter olabilir.")]
        public string? ChassisNumber { get; set; }

        [Range(0, 2000000, ErrorMessage = "Kilometre 0-2.000.000 arasında olmalıdır.")]
        public int? Mileage { get; set; }

        [MaxLength(20, ErrorMessage = "Motor numarası en fazla 20 karakter olabilir.")]
        public string? EngineNumber { get; set; }

        [MaxLength(500, ErrorMessage = "Not en fazla 500 karakter olabilir.")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "Müşteri seçimi zorunludur.")]
        public int CustomerId { get; set; }

        public int? FuelTypeId { get; set; }
        public int? TransmissionTypeId { get; set; }
        public int? CarTypeId { get; set; }
    }
}

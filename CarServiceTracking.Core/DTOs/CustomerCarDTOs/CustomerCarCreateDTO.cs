using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.Core.DTOs.CustomerCarDTOs
{
    public class CustomerCarCreateDTO
    {
        [Required(ErrorMessage = "Müşteri seçimi zorunludur.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Marka/Model alanı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Marka/Model en fazla 100 karakter olabilir.")]
        public string BrandModel { get; set; } = string.Empty;

        [Required(ErrorMessage = "Plaka alanı zorunludur.")]
        [MaxLength(15, ErrorMessage = "Plaka en fazla 15 karakter olabilir.")]
        public string PlateNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yıl alanı zorunludur.")]
        [Range(1950, 2030, ErrorMessage = "Yıl 1950-2030 arasında olmalıdır.")]
        public int Year { get; set; }

        [Range(0, 2000000, ErrorMessage = "Kilometre 0-2.000.000 arasında olmalıdır.")]
        public int? Mileage { get; set; }

        [MaxLength(30, ErrorMessage = "Renk en fazla 30 karakter olabilir.")]
        public string? Color { get; set; }

        public bool IsInService { get; set; }
    }
}

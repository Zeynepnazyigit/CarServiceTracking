using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.Core.DTOs.MechanicDTOs
{
    public class MechanicCreateDTO
    {
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-posta alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [MaxLength(100, ErrorMessage = "E-posta en fazla 100 karakter olabilir.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon alanı zorunludur.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [MaxLength(20, ErrorMessage = "Telefon en fazla 20 karakter olabilir.")]
        public string Phone { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "Uzmanlık alanı en fazla 100 karakter olabilir.")]
        public string? Specialization { get; set; }

        [Required(ErrorMessage = "Saat ücreti zorunludur.")]
        [Range(0.01, 9999.99, ErrorMessage = "Saat ücreti 0.01-9999.99 arasında olmalıdır.")]
        public decimal HourlyRate { get; set; }

        public bool IsAvailable { get; set; } = true;

        [MaxLength(500, ErrorMessage = "Not en fazla 500 karakter olabilir.")]
        public string? Notes { get; set; }
    }
}

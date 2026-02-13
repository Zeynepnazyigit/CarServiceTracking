using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.Core.DTOs.CustomerDTOs
{
    public class CustomerCreateDTO
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

        [MaxLength(200, ErrorMessage = "Adres en fazla 200 karakter olabilir.")]
        public string? Address { get; set; }

        [MaxLength(50, ErrorMessage = "Şehir en fazla 50 karakter olabilir.")]
        public string? City { get; set; }

        [MaxLength(50, ErrorMessage = "Ülke en fazla 50 karakter olabilir.")]
        public string? Country { get; set; }

        [MaxLength(10, ErrorMessage = "Posta kodu en fazla 10 karakter olabilir.")]
        public string? PostalCode { get; set; }

        [MaxLength(20, ErrorMessage = "Vergi numarası en fazla 20 karakter olabilir.")]
        public string? TaxNumber { get; set; }

        [MaxLength(100, ErrorMessage = "Firma adı en fazla 100 karakter olabilir.")]
        public string? CompanyName { get; set; }

        [MaxLength(500, ErrorMessage = "Not en fazla 500 karakter olabilir.")]
        public string? Notes { get; set; }

        public int? CustomerTypeId { get; set; }
    }
}

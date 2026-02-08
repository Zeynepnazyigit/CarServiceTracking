using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.Customers
{
    public class CustomerCreateVM
    {
        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [StringLength(100, ErrorMessage = "Ad en fazla 100 karakter olabilir")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        [StringLength(100, ErrorMessage = "Soyad en fazla 100 karakter olabilir")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-posta adresi zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [StringLength(200, ErrorMessage = "E-posta en fazla 200 karakter olabilir")]
        [Display(Name = "E-posta")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon numarası zorunludur")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [StringLength(20, ErrorMessage = "Telefon en fazla 20 karakter olabilir")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Adres en fazla 500 karakter olabilir")]
        [Display(Name = "Adres")]
        public string? Address { get; set; }

        [StringLength(100, ErrorMessage = "Şehir en fazla 100 karakter olabilir")]
        [Display(Name = "Şehir")]
        public string? City { get; set; }

        [StringLength(100, ErrorMessage = "Ülke en fazla 100 karakter olabilir")]
        [Display(Name = "Ülke")]
        public string? Country { get; set; }

        [StringLength(20, ErrorMessage = "Posta kodu en fazla 20 karakter olabilir")]
        [Display(Name = "Posta Kodu")]
        public string? PostalCode { get; set; }

        [StringLength(50, ErrorMessage = "Vergi numarası en fazla 50 karakter olabilir")]
        [Display(Name = "Vergi Numarası")]
        public string? TaxNumber { get; set; }

        [StringLength(200, ErrorMessage = "Firma adı en fazla 200 karakter olabilir")]
        [Display(Name = "Firma Adı")]
        public string? CompanyName { get; set; }

        [StringLength(1000, ErrorMessage = "Notlar en fazla 1000 karakter olabilir")]
        [Display(Name = "Notlar")]
        public string? Notes { get; set; }

        [Display(Name = "Müşteri Tipi")]
        public int? CustomerTypeId { get; set; }
    }
}

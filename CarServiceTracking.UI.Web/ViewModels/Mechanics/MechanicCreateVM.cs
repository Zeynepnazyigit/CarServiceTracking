using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.Mechanics
{
    public class MechanicCreateVM
    {
        [Required(ErrorMessage = "Ad zorunludur")]
        [StringLength(100, ErrorMessage = "Ad en fazla 100 karakter olabilir")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyad zorunludur")]
        [StringLength(100, ErrorMessage = "Soyad en fazla 100 karakter olabilir")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Uzmanlık alanı zorunludur")]
        [StringLength(200, ErrorMessage = "Uzmanlık alanı en fazla 200 karakter olabilir")]
        public string Specialization { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon numarası zorunludur")]
        [StringLength(20, ErrorMessage = "Telefon numarası en fazla 20 karakter olabilir")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "İşe giriş tarihi zorunludur")]
        [DataType(DataType.Date)]
        [Display(Name = "İşe Giriş Tarihi")]
        public DateTime HireDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Saatlik ücret zorunludur")]
        [Range(0.01, 999999.99, ErrorMessage = "Saatlik ücret 0.01 ile 999999.99 arasında olmalıdır")]
        [Display(Name = "Saatlik Ücret")]
        public decimal HourlyRate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}

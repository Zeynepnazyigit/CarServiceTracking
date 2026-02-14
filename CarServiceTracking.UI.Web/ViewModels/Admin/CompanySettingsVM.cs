using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.Admin
{
    public class CompanySettingsVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Firma adı zorunludur")]
        [StringLength(200)]
        public string CompanyName { get; set; } = "CarServiceTracking";

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [StringLength(200)]
        public string Email { get; set; } = "info@carservice.com";

        [StringLength(50)]
        public string Phone { get; set; } = "+90 (312) 123 45 67";

        [StringLength(500)]
        public string Address { get; set; } = "Çankaya, Ankara";

        public string DefaultLanguage { get; set; } = "tr-TR";
        public string Currency { get; set; } = "TRY";
        public string DateFormat { get; set; } = "dd/MM/yyyy";
        public bool EmailNotifications { get; set; } = true;
        public bool SmsNotifications { get; set; }

        [Range(5, 1440, ErrorMessage = "Oturum süresi 5-1440 dakika arasında olmalıdır")]
        public int SessionTimeoutMinutes { get; set; } = 30;

        [Range(6, 32, ErrorMessage = "Minimum şifre uzunluğu 6-32 arasında olmalıdır")]
        public int MinPasswordLength { get; set; } = 6;

        public bool TwoFactorAuth { get; set; }
    }
}

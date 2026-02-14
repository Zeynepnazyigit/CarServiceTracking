namespace CarServiceTracking.Core.Entities
{
    /// <summary>
    /// Firma/genel sistem ayarları. Tek kayıt (Id=1) kullanılır.
    /// </summary>
    public class CompanySettings : BaseEntity
    {
        public string CompanyName { get; set; } = "CarServiceTracking";
        public string Email { get; set; } = "info@carservice.com";
        public string Phone { get; set; } = "+90 (312) 123 45 67";
        public string Address { get; set; } = "Çankaya, Ankara";
        public string DefaultLanguage { get; set; } = "tr-TR";
        public string Currency { get; set; } = "TRY";
        public string DateFormat { get; set; } = "dd/MM/yyyy";
        public bool EmailNotifications { get; set; } = true;
        public bool SmsNotifications { get; set; }
        public int SessionTimeoutMinutes { get; set; } = 30;
        public int MinPasswordLength { get; set; } = 6;
        public bool TwoFactorAuth { get; set; }
    }
}

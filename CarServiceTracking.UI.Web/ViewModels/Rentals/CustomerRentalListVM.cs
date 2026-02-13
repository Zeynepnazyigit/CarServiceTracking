namespace CarServiceTracking.UI.Web.ViewModels.Rentals
{
    /// <summary>
    /// Customer panel icin kiralama listesi ViewModel
    /// </summary>
    public class CustomerRentalListVM
    {
        public int Id { get; set; }
        public string AgreementNumber { get; set; } = string.Empty;
        public string VehicleInfo { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;

        // Odeme bilgileri
        public int? InvoiceId { get; set; }
        public string PaymentStatusText { get; set; } = "Bekliyor";

        public string DateRange => $"{StartDate:dd.MM.yyyy} - {EndDate:dd.MM.yyyy}";

        public string StatusBadgeClass => Status switch
        {
            "Active" => "badge bg-success",
            "Completed" => "badge bg-primary",
            "Cancelled" => "badge bg-danger",
            _ => "badge bg-secondary"
        };

        public string StatusText => Status switch
        {
            "Active" => "Aktif",
            "Completed" => "Tamamlandı",
            "Cancelled" => "İptal",
            _ => Status
        };

        public string PaymentBadgeClass => PaymentStatusText switch
        {
            "Ödendi" => "badge bg-success",
            "Kısmi Ödendi" => "badge bg-warning",
            "Bekliyor" => "badge bg-danger",
            _ => "badge bg-secondary"
        };
    }
}

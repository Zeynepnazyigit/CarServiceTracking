namespace CarServiceTracking.UI.Web.ViewModels.Rentals
{
    /// <summary>
    /// Kiralama detay ViewModel
    /// </summary>
    public class RentalDetailVM
    {
        public int Id { get; set; }
        public string AgreementNumber { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int RentalVehicleId { get; set; }
        public string VehicleInfo { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? StartMileage { get; set; }
        public int? EndMileage { get; set; }
        public decimal DailyRate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DepositAmount { get; set; }
        public bool DepositRefunded { get; set; }
        public DateTime? DepositRefundedDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Notes { get; set; }

        // Odeme bilgileri (faturadan gelir)
        public int? InvoiceId { get; set; }
        public string? PaymentStatusText { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public bool HasInvoice => InvoiceId.HasValue && InvoiceId.Value > 0;

        public string DateRange => $"{StartDate:dd.MM.yyyy} - {EndDate:dd.MM.yyyy}";
        public int TotalDays => (EndDate - StartDate).Days;

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

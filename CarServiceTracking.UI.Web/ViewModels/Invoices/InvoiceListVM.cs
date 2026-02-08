namespace CarServiceTracking.UI.Web.ViewModels.Invoices
{
    public class InvoiceListVM
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public int ServiceRequestId { get; set; }
        public string ServiceRequestInfo { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;

        /// <summary>
        /// Fatura tarihi formatlanmış hali
        /// </summary>
        public string FormattedDate => InvoiceDate.ToString("dd.MM.yyyy");

        /// <summary>
        /// Status badge renk sınıfı
        /// </summary>
        public string StatusBadgeClass => PaymentStatus switch
        {
            "Paid" => "badge bg-success",
            "Partial" => "badge bg-warning",
            "Unpaid" => "badge bg-danger",
            _ => "badge bg-secondary"
        };

        /// <summary>
        /// Ödeme durumu Türkçe
        /// </summary>
        public string StatusText => PaymentStatus switch
        {
            "Paid" => "Ödendi",
            "Partial" => "Kısmi Ödendi",
            "Unpaid" => "Ödenmedi",
            _ => PaymentStatus
        };
    }
}

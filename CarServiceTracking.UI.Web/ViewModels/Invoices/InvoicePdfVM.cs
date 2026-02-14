namespace CarServiceTracking.UI.Web.ViewModels.Invoices
{
    public class InvoicePdfVM
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string CarInfo { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal LaborCost { get; set; }
        public decimal PartsTotal { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public string? Notes { get; set; }

        /// <summary>
        /// Kiralama faturası mı? (true ise etiketler "Kiralama Ücreti" / "Depozito" olur)
        /// </summary>
        public bool IsRentalInvoice { get; set; }
    }
}

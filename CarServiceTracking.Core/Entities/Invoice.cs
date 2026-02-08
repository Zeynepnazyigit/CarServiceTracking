using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.Entities
{
    /// <summary>
    /// Servis faturaları
    /// </summary>
    public class Invoice : BaseEntity
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; }
        public int ServiceRequestId { get; set; }
        public int CustomerId { get; set; }
        
        // Maliyet Detayları
        public decimal PartsTotal { get; set; }
        public decimal LaborCost { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxRate { get; set; } = 20; // KDV %20
        public decimal TaxAmount { get; set; }
        public decimal GrandTotal { get; set; }
        
        // Ödeme Durumu
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        
        public DateTime? DueDate { get; set; }
        public string? Notes { get; set; }

        // Navigation Properties
        public virtual ServiceRequest ServiceRequest { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}

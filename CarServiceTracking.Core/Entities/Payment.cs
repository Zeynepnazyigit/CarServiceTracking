using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.Entities
{
    /// <summary>
    /// Ödeme kayıtları (faturaya bağlı)
    /// </summary>
    public class Payment : BaseEntity
    {
        public int InvoiceId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string? TransactionId { get; set; }
        public string? Reference { get; set; }
        public string? Notes { get; set; }

        // Navigation Properties
        public virtual Invoice Invoice { get; set; } = null!;
    }
}

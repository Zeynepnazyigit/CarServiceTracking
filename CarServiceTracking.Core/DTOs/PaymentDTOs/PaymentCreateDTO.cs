using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.DTOs.PaymentDTOs
{
    public class PaymentCreateDTO
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string? ReferenceNumber { get; set; }
        public string? Notes { get; set; }
        public string? ProcessedBy { get; set; }
    }
}

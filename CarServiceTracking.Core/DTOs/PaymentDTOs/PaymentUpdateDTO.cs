using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.DTOs.PaymentDTOs
{
    public class PaymentUpdateDTO
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? Notes { get; set; }
    }
}

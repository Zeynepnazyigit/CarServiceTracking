using CarServiceTracking.UI.Web.Enums;

namespace CarServiceTracking.UI.Web.Models.ApiModels.PaymentApiModels
{
    public class PaymentCreateApiModel
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

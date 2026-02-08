using CarServiceTracking.UI.Web.Enums;

namespace CarServiceTracking.UI.Web.Models.ApiModels.PaymentApiModels
{
    public class PaymentListApiModel
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

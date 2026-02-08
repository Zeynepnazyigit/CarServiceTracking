using CarServiceTracking.UI.Web.Enums;

namespace CarServiceTracking.UI.Web.Models.ApiModels.InvoiceApiModels
{
    public class InvoiceUpdateApiModel
    {
        public int Id { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal LaborCost { get; set; }
        public decimal PartsTotal { get; set; }
        public decimal TaxRate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string? Notes { get; set; }
    }
}

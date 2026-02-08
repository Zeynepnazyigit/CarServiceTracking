namespace CarServiceTracking.Core.DTOs.InvoiceDTOs
{
    public class InvoiceCreateDTO
    {
        public int ServiceRequestId { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        public decimal LaborCost { get; set; }
        public decimal PartsTotal { get; set; }
        public decimal TaxRate { get; set; } = 20m;
        public string? Notes { get; set; }
    }
}

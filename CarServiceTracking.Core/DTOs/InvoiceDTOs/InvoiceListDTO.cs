using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.DTOs.InvoiceDTOs
{
    public class InvoiceListDTO
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public int? ServiceRequestId { get; set; }
        public int? RentalAgreementId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string? RentalInfo { get; set; }          // Kiralama faturasi icin arac bilgisi
        public DateTime InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Fatura tipi: Servis veya Kiralama
        /// </summary>
        public bool IsRentalInvoice => RentalAgreementId.HasValue;
    }
}

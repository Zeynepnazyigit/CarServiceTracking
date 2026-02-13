using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.Core.DTOs.InvoiceDTOs
{
    public class InvoiceCreateDTO
    {
        public int? ServiceRequestId { get; set; }       // Servis faturasi icin
        public int? RentalAgreementId { get; set; }      // Kiralama faturasi icin
        public int CustomerId { get; set; }

        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        public DateTime? DueDate { get; set; }

        [Range(0, 999999, ErrorMessage = "İşçilik ücreti 0-999999 arasında olmalıdır.")]
        public decimal LaborCost { get; set; }

        [Range(0, 999999, ErrorMessage = "Parça toplamı 0-999999 arasında olmalıdır.")]
        public decimal PartsTotal { get; set; }

        [Range(0, 100, ErrorMessage = "KDV oranı 0-100 arasında olmalıdır.")]
        public decimal TaxRate { get; set; } = 20m;

        [MaxLength(500, ErrorMessage = "Not en fazla 500 karakter olabilir.")]
        public string? Notes { get; set; }
    }
}

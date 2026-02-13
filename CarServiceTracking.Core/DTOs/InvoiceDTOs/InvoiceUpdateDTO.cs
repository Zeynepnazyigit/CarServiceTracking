using System.ComponentModel.DataAnnotations;
using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.DTOs.InvoiceDTOs
{
    public class InvoiceUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        public DateTime? DueDate { get; set; }

        [Range(0, 999999, ErrorMessage = "İşçilik ücreti 0-999999 arasında olmalıdır.")]
        public decimal LaborCost { get; set; }

        [Range(0, 999999, ErrorMessage = "Parça toplamı 0-999999 arasında olmalıdır.")]
        public decimal PartsTotal { get; set; }

        [Range(0, 100, ErrorMessage = "KDV oranı 0-100 arasında olmalıdır.")]
        public decimal TaxRate { get; set; }

        [Required(ErrorMessage = "Ödeme durumu zorunludur.")]
        public PaymentStatus PaymentStatus { get; set; }

        [MaxLength(500, ErrorMessage = "Not en fazla 500 karakter olabilir.")]
        public string? Notes { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.DTOs.PaymentDTOs
{
    public class PaymentCreateDTO
    {
        [Required(ErrorMessage = "Fatura seçimi zorunludur.")]
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "Tutar zorunludur.")]
        [Range(0.01, 9999999.99, ErrorMessage = "Tutar 0.01-9999999.99 arasında olmalıdır.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Ödeme yöntemi zorunludur.")]
        public PaymentMethod PaymentMethod { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [MaxLength(50, ErrorMessage = "Referans numarası en fazla 50 karakter olabilir.")]
        public string? ReferenceNumber { get; set; }

        [MaxLength(500, ErrorMessage = "Not en fazla 500 karakter olabilir.")]
        public string? Notes { get; set; }

        [MaxLength(100, ErrorMessage = "İşlemi yapan en fazla 100 karakter olabilir.")]
        public string? ProcessedBy { get; set; }
    }
}

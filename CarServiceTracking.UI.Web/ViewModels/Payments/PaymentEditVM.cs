using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.Payments
{
    public class PaymentEditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fatura seçimi zorunludur")]
        public int InvoiceId { get; set; }

    // Display için
    public string InvoiceNumber { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ödeme tarihi zorunludur")]
        [DataType(DataType.DateTime)]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Tutar zorunludur")]
        [Range(0.01, 999999.99, ErrorMessage = "Tutar 0.01 ile 999999.99 arasında olmalıdır")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Ödeme yöntemi zorunludur")]
        [StringLength(50, ErrorMessage = "Ödeme yöntemi en fazla 50 karakter olabilir")]
        public string PaymentMethod { get; set; } = "Cash";

        [StringLength(100, ErrorMessage = "İşlem ID en fazla 100 karakter olabilir")]
        public string? TransactionId { get; set; }

        [StringLength(500, ErrorMessage = "Notlar en fazla 500 karakter olabilir")]
        public string? Notes { get; set; }
    }
}

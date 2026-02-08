using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.Invoices
{
    public class InvoiceCreateVM
    {
        [Required(ErrorMessage = "Fatura numarası zorunludur")]
        [StringLength(50, ErrorMessage = "Fatura numarası en fazla 50 karakter olabilir")]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Servis talebi seçimi zorunludur")]
        public int ServiceRequestId { get; set; }

        [Required(ErrorMessage = "Fatura tarihi zorunludur")]
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Toplam tutar zorunludur")]
        [Range(0.01, 999999.99, ErrorMessage = "Toplam tutar 0.01 ile 999999.99 arasında olmalıdır")]
        public decimal TotalAmount { get; set; }

        [Range(0, 999999.99, ErrorMessage = "Ödenen tutar 0 ile 999999.99 arasında olmalıdır")]
        public decimal PaidAmount { get; set; }

        [StringLength(1000, ErrorMessage = "Notlar en fazla 1000 karakter olabilir")]
        public string? Notes { get; set; }
    }
}

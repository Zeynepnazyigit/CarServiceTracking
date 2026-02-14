using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.Invoices
{
    public class InvoiceEditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fatura numarası zorunludur")]
        [StringLength(50, ErrorMessage = "Fatura numarası en fazla 50 karakter olabilir")]
        public string InvoiceNumber { get; set; } = string.Empty;

        public int? ServiceRequestId { get; set; }

        [Required(ErrorMessage = "Fatura tarihi zorunludur")]
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        [Required(ErrorMessage = "Vade tarihi zorunludur")]
        [DataType(DataType.Date)]
        [Display(Name = "Vade Tarihi")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Toplam tutar zorunludur")]
        [Range(0.01, 999999.99, ErrorMessage = "Toplam tutar 0.01 ile 999999.99 arasında olmalıdır")]
        public decimal TotalAmount { get; set; }

        [Range(0, 999999.99, ErrorMessage = "Ödenen tutar 0 ile 999999.99 arasında olmalıdır")]
        public decimal PaidAmount { get; set; }

        public decimal RemainingAmount { get; set; }

        public string PaymentStatus { get; set; } = "Pending";

        public decimal LaborCost { get; set; }
        public decimal PartsTotal { get; set; }
        public decimal TaxRate { get; set; }

        [StringLength(1000, ErrorMessage = "Notlar en fazla 1000 karakter olabilir")]
        [Display(Name = "Notlar")]
        public string? Notes { get; set; }
    }
}

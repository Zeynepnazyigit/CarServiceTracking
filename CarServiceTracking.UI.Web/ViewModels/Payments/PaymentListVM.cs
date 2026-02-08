namespace CarServiceTracking.UI.Web.ViewModels.Payments
{
    public class PaymentListVM
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string? TransactionId { get; set; }
        public string? Notes { get; set; }

        /// <summary>
        /// Ödeme tarihi formatlanmış hali
        /// </summary>
        public string FormattedDate => PaymentDate.ToString("dd.MM.yyyy HH:mm");

        /// <summary>
        /// Ödeme yöntemi Türkçe
        /// </summary>
        public string PaymentMethodText => PaymentMethod switch
        {
            "Cash" => "Nakit",
            "CreditCard" => "Kredi Kartı",
            "DebitCard" => "Banka Kartı",
            "BankTransfer" => "Havale/EFT",
            _ => PaymentMethod
        };
    }
}

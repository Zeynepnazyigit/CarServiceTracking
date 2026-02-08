namespace CarServiceTracking.UI.Web.Enums
{
    public enum PaymentStatus
    {
        Pending = 1,     // Ödeme bekliyor
        Partial = 2,     // Kısmi ödendi
        Paid = 3,        // Tam ödendi
        Overdue = 4,     // Vadesi geçti
        Cancelled = 5    // İptal edildi
    }
}

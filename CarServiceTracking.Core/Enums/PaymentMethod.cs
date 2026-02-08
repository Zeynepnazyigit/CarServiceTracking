namespace CarServiceTracking.Core.Enums
{
    public enum PaymentMethod
    {
        Cash = 1,           // Nakit
        CreditCard = 2,     // Kredi Kartı
        DebitCard = 3,      // Banka Kartı
        BankTransfer = 4,   // Havale/EFT
        Check = 5,          // Çek
        Other = 6           // Diğer
    }
}

namespace CarServiceTracking.UI.Web.Enums
{
    public enum RentalStatus
    {
        Reserved = 1,    // Rezerve edildi
        Active = 2,      // Aktif kiralama
        Completed = 3,   // Tamamlandı
        Cancelled = 4,   // İptal edildi
        Overdue = 5      // İadesi gecikti
    }
}

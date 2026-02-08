namespace CarServiceTracking.Core.Enums
{
    public enum AppointmentStatus
    {
        Pending = 1,      // Onay bekliyor
        Confirmed = 2,    // Onaylandı
        InProgress = 3,   // Devam ediyor
        Completed = 4,    // Tamamlandı
        Cancelled = 5,    // İptal edildi
        NoShow = 6        // Gelmedi
    }
}

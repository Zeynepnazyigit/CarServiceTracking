namespace CarServiceTracking.UI.Web.ViewModels.CustomerCars
{
    public class CustomerCarVM
    {
        public int Id { get; set; }

        // Marka + Model (UI için)
        public string BrandModel { get; set; } = "";

        // Plaka
        public string PlateNumber { get; set; } = "";

        // Model yılı
        public int Year { get; set; }

        // Opsiyonel bilgiler
        public int? Mileage { get; set; }
        public string? Color { get; set; }

        // Servis durumu
        public bool IsInService { get; set; }

        // ✅ UI’da kullanılacak TEK durum metni
        public string StatusText
            => IsInService ? "Serviste" : "Aktif";
    }
}

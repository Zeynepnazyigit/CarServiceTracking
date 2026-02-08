namespace CarServiceTracking.UI.Web.ViewModels.Rentals
{
    public class RentalVehicleListVM
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string FuelType { get; set; } = string.Empty;
        public string TransmissionType { get; set; } = string.Empty;
        public string? Color { get; set; }
        public decimal DailyRate { get; set; }
        public bool IsAvailable { get; set; }
        
        /// <summary>
        /// Araç resmi URL'si
        /// </summary>
        public string? ImageUrl { get; set; }
        
        /// <summary>
        /// Varsayılan resim yoksa placeholder
        /// </summary>
        public string ImageUrlOrDefault => !string.IsNullOrEmpty(ImageUrl) 
            ? ImageUrl 
            : "https://via.placeholder.com/400x250/343a40/ffffff?text=Araç+Resmi";

        /// <summary>
        /// Araç bilgisi tam hali
        /// </summary>
        public string VehicleInfo => $"{Brand} {Model} ({Year}) - {PlateNumber}";

        /// <summary>
        /// Müsaitlik durumu badge sınıfı
        /// </summary>
        public string AvailabilityBadge => IsAvailable ? "badge bg-success" : "badge bg-danger";

        /// <summary>
        /// Müsaitlik durumu text
        /// </summary>
        public string AvailabilityText => IsAvailable ? "Müsait" : "Kirada";
    }
}

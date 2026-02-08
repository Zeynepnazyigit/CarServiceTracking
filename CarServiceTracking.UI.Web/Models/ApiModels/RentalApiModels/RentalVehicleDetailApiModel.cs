namespace CarServiceTracking.UI.Web.Models.ApiModels.RentalApiModels
{
    public class RentalVehicleDetailApiModel
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Color { get; set; } = string.Empty;
        public decimal DailyRate { get; set; }
        public bool IsAvailable { get; set; }
        public int Mileage { get; set; }
        public string? FuelType { get; set; }
        public string? TransmissionType { get; set; }
        public string? Notes { get; set; }

        /// <summary>
        /// Araç resim URL'si
        /// </summary>
        public string? ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

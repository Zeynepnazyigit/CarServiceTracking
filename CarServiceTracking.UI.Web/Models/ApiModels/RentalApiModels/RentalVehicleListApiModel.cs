using CarServiceTracking.UI.Web.Enums;

namespace CarServiceTracking.UI.Web.Models.ApiModels.RentalApiModels
{
    public class RentalVehicleListApiModel
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public bool IsAvailable { get; set; }
        public int ActiveRentals { get; set; }
        public string? ImageUrl { get; set; }
        public string? FuelType { get; set; }
        public string? TransmissionType { get; set; }
        public string? Color { get; set; }
    }
}

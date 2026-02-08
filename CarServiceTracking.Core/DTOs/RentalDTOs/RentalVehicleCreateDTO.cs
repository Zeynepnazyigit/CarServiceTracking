namespace CarServiceTracking.Core.DTOs.RentalDTOs
{
    public class RentalVehicleCreateDTO
    {
        public string PlateNumber { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Color { get; set; } = string.Empty;
        public decimal DailyRate { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int Mileage { get; set; }
        public string? FuelType { get; set; }
        public string? TransmissionType { get; set; }
        public string? Notes { get; set; }
    }
}

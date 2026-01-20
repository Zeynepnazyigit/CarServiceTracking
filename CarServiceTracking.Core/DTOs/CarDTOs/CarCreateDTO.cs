namespace CarServiceTracking.Core.DTOs.CarDTOs
{
    public class CarCreateDTO
    {
        public string PlateNumber { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string? Color { get; set; }
        public string? ChassisNumber { get; set; }
        public int? Mileage { get; set; }
        public string? EngineNumber { get; set; }
        public string? Notes { get; set; }
        public int CustomerId { get; set; }
        public int? FuelTypeId { get; set; }
        public int? TransmissionTypeId { get; set; }
        public int? CarTypeId { get; set; }
    }
}
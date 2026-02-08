namespace CarServiceTracking.UI.Web.ViewModels.Cars
{
    public class CarDetailVM
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; } = "";
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public string BrandModel { get; set; } = "";
        public int Year { get; set; }
        public string? Color { get; set; }
        public string? ChassisNumber { get; set; }
        public int? Mileage { get; set; }
        public string? EngineNumber { get; set; }
        public string? Notes { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = "";
        public int? FuelTypeId { get; set; }
        public string? FuelTypeName { get; set; }
        public int? TransmissionTypeId { get; set; }
        public string? TransmissionTypeName { get; set; }
        public int? CarTypeId { get; set; }
        public string? CarTypeName { get; set; }
        public bool IsActive { get; set; }
        public decimal? DailyPrice { get; set; }
        public string? ImageUrl { get; set; }
    }
}

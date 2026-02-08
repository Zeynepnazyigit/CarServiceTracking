namespace CarServiceTracking.Core.DTOs.CustomerCarDTOs
{
    public class CustomerCarCreateDTO
    {
        public int CustomerId { get; set; }
        public string BrandModel { get; set; } = string.Empty;
        public string PlateNumber { get; set; } = string.Empty;
        public int Year { get; set; }
        public int? Mileage { get; set; }
        public string? Color { get; set; }
        public bool IsInService { get; set; }
    }
}

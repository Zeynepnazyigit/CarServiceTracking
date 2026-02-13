namespace CarServiceTracking.Core.DTOs.CustomerCarDTOs
{
    public class CustomerCarListDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string BrandModel { get; set; } = "";
        public string PlateNumber { get; set; } = "";
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string? Color { get; set; }
        public bool IsInService { get; set; }
    }
}

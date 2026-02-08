using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.Entities
{
    public class CustomerCar : BaseEntity
    {
        public int CustomerId { get; set; }
        public string BrandModel { get; set; } = null!;
        public string PlateNumber { get; set; } = null!;
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string? Color { get; set; }
        public bool IsInService { get; set; }
    }
}

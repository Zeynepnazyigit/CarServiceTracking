namespace CarServiceTracking.UI.Web.ViewModels.Cars
{
    public class CarListVM
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; } = "";
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public string BrandModel { get; set; } = "";
        public int Year { get; set; }
        public string? Color { get; set; }
        public int? Mileage { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = "";
        public string? FuelTypeName { get; set; }
        public string? TransmissionTypeName { get; set; }
        public string? CarTypeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

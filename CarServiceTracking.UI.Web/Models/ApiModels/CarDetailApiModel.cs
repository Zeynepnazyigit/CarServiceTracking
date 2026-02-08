namespace CarServiceTracking.UI.Web.Models.ApiModels
{
    public class CarDetailApiModel
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; } = "";

        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public string BrandModel { get; set; } = "";

        public int Year { get; set; }
        public string? Color { get; set; }
        public int? Mileage { get; set; }

        public string? FuelTypeName { get; set; }
        public string? TransmissionTypeName { get; set; }
        public string? CarTypeName { get; set; }

        public int IsActive { get; set; } // API 0/1 gönderiyor diye int

        public decimal? DailyPrice { get; set; }
        public string? ImageUrl { get; set; }

        public string CustomerName { get; set; } = "";
    }
}

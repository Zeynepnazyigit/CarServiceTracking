using System;

namespace CarServiceTracking.UI.Web.Models.ApiModels.CarApiModels
{
    public class CarListApiModel
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string BrandModel => $"{Brand} {Model}";
        public int Year { get; set; }
        public string? Color { get; set; }
        public int? Mileage { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public string? FuelTypeName { get; set; }
        public string? TransmissionTypeName { get; set; }
        public string? CarTypeName { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

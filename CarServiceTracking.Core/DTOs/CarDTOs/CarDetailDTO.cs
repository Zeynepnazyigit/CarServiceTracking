using System;

namespace CarServiceTracking.Core.DTOs.CarDTOs
{
    public class CarDetailDTO
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string BrandModel => $"{Brand} {Model}";

        public int Year { get; set; }
        public string? Color { get; set; }
        public string? ChassisNumber { get; set; }
        public int? Mileage { get; set; }
        public string? EngineNumber { get; set; }
        public string? Notes { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public int? FuelTypeId { get; set; }
        public string? FuelTypeName { get; set; }

        public int? TransmissionTypeId { get; set; }
        public string? TransmissionTypeName { get; set; }

        public int? CarTypeId { get; set; }
        public string? CarTypeName { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

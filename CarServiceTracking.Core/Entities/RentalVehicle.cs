namespace CarServiceTracking.Core.Entities
{
    /// <summary>
    /// Kiralık araç filosu
    /// </summary>
    public class RentalVehicle : BaseEntity
    {
        public string PlateNumber { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string? Color { get; set; }
        public string? FuelType { get; set; }
        public string? TransmissionType { get; set; }
        public int Mileage { get; set; }
        public decimal DailyRate { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string? VehicleCondition { get; set; }
        public string? Notes { get; set; }
        
        /// <summary>
        /// Araç resmi URL'si
        /// </summary>
        public string? ImageUrl { get; set; }
        public DateTime? LastMaintenanceDate { get; set; }
        public DateTime? NextMaintenanceDate { get; set; }

        // Hesaplanan Property
        public string DisplayName => $"{Brand} {Model} ({PlateNumber})";

        // Navigation Properties
        public virtual ICollection<RentalAgreement> RentalAgreements { get; set; } = new List<RentalAgreement>();
    }
}

using System;
using System.Collections.Generic;

namespace CarServiceTracking.API.Temp;

public partial class RentalVehicle
{
    public int Id { get; set; }

    public string PlateNumber { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public string? Color { get; set; }

    public string? FuelType { get; set; }

    public string? TransmissionType { get; set; }

    public int Mileage { get; set; }

    public decimal DailyRate { get; set; }

    public bool IsAvailable { get; set; }

    public string? VehicleCondition { get; set; }

    public string? Notes { get; set; }

    public DateTime? LastMaintenanceDate { get; set; }

    public DateTime? NextMaintenanceDate { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<RentalAgreement> RentalAgreements { get; set; } = new List<RentalAgreement>();
}

using System;
using System.Collections.Generic;

namespace CarServiceTracking.API.Temp;

public partial class RentalAgreement
{
    public int Id { get; set; }

    public string AgreementNumber { get; set; } = null!;

    public int CustomerId { get; set; }

    public int RentalVehicleId { get; set; }

    public int? ServiceRequestId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime? ActualReturnDate { get; set; }

    public decimal DailyRate { get; set; }

    public int TotalDays { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal DepositAmount { get; set; }

    public decimal? LateFee { get; set; }

    public int Status { get; set; }

    public int StartMileage { get; set; }

    public int? EndMileage { get; set; }

    public string? PickupNotes { get; set; }

    public string? ReturnNotes { get; set; }

    public string? DamageNotes { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual RentalVehicle RentalVehicle { get; set; } = null!;

    public virtual ServiceRequest? ServiceRequest { get; set; }
}

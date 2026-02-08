using System;
using System.Collections.Generic;

namespace CarServiceTracking.API.Temp;

public partial class ServiceAssignment
{
    public int Id { get; set; }

    public int ServiceRequestId { get; set; }

    public int MechanicId { get; set; }

    public DateTime AssignedAt { get; set; }

    public DateTime? StartedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public decimal? EstimatedHours { get; set; }

    public decimal? ActualHours { get; set; }

    public string? Notes { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Mechanic Mechanic { get; set; } = null!;

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}

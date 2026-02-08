using System;
using System.Collections.Generic;

namespace CarServiceTracking.API.Temp;

public partial class ServicePart
{
    public int Id { get; set; }

    public int ServiceRequestId { get; set; }

    public int PartId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public string? Notes { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Part Part { get; set; } = null!;

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}

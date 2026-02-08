using System;
using System.Collections.Generic;

namespace CarServiceTracking.API.Temp;

public partial class ServiceRequest
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int CarId { get; set; }

    public string ProblemDescription { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PreferredDate { get; set; }

    public int Status { get; set; }

    public decimal? ServicePrice { get; set; }

    public string? AdminNote { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Invoice? Invoice { get; set; }

    public virtual RentalAgreement? RentalAgreement { get; set; }

    public virtual ICollection<ServiceAssignment> ServiceAssignments { get; set; } = new List<ServiceAssignment>();

    public virtual ICollection<ServicePart> ServiceParts { get; set; } = new List<ServicePart>();
}

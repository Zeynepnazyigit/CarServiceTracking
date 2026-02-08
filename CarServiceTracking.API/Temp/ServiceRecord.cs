using System;
using System.Collections.Generic;

namespace CarServiceTracking.API.Temp;

public partial class ServiceRecord
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime ServiceDate { get; set; }

    public decimal? TotalPrice { get; set; }

    public int CarId { get; set; }

    public int CustomerId { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}

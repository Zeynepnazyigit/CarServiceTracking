using System;
using System.Collections.Generic;

namespace CarServiceTracking.API.Temp;

public partial class Part
{
    public int Id { get; set; }

    public string PartName { get; set; } = null!;

    public string PartCode { get; set; } = null!;

    public string? Category { get; set; }

    public string? Description { get; set; }

    public decimal UnitPrice { get; set; }

    public int StockQuantity { get; set; }

    public int MinStockLevel { get; set; }

    public string? Supplier { get; set; }

    public string? SupplierContact { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<ServicePart> ServiceParts { get; set; } = new List<ServicePart>();
}

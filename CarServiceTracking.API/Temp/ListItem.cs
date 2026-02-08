using System;
using System.Collections.Generic;

namespace CarServiceTracking.API.Temp;

public partial class ListItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ListType { get; set; } = null!;

    public string? Description { get; set; }

    public int? ParentId { get; set; }

    public int SortOrder { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Car> CarCarTypes { get; set; } = new List<Car>();

    public virtual ICollection<Car> CarFuelTypes { get; set; } = new List<Car>();

    public virtual ICollection<Car> CarTransmissionTypes { get; set; } = new List<Car>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<ListItem> InverseParent { get; set; } = new List<ListItem>();

    public virtual ListItem? Parent { get; set; }
}

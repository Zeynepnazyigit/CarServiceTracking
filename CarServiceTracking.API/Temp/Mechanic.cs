using System;
using System.Collections.Generic;

namespace CarServiceTracking.API.Temp;

public partial class Mechanic
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Specialization { get; set; }

    public decimal HourlyRate { get; set; }

    public DateTime HireDate { get; set; }

    public string? Address { get; set; }

    public string? Notes { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<ServiceAssignment> ServiceAssignments { get; set; } = new List<ServiceAssignment>();
}

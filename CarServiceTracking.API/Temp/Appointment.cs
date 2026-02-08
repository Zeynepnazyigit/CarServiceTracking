using System;
using System.Collections.Generic;

namespace CarServiceTracking.API.Temp;

public partial class Appointment
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int CarId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string TimeSlot { get; set; } = null!;

    public int Status { get; set; }

    public string? ServiceType { get; set; }

    public string? Description { get; set; }

    public string? CustomerNotes { get; set; }

    public string? AdminNotes { get; set; }

    public DateTime? ConfirmedAt { get; set; }

    public DateTime? CancelledAt { get; set; }

    public string? CancellationReason { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}

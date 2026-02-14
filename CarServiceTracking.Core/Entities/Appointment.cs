using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.Entities
{
    /// <summary>
    /// Randevu sistemi
    /// </summary>
    public class Appointment : BaseEntity
    {
        public int CustomerId { get; set; }
        public int? CarId { get; set; }
        public int? CustomerCarId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string TimeSlot { get; set; } = string.Empty; // "09:00-10:00"
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
        public string? ServiceType { get; set; }
        public string? Description { get; set; }
        public string? CustomerNotes { get; set; }
        public string? AdminNotes { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        public DateTime? CancelledAt { get; set; }
        public string? CancellationReason { get; set; }

        // Navigation Properties
        public virtual Customer Customer { get; set; } = null!;
        public virtual Car? Car { get; set; }
        public virtual CustomerCar? CustomerCar { get; set; }
    }
}

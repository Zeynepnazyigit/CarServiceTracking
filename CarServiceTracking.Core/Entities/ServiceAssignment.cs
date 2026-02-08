namespace CarServiceTracking.Core.Entities
{
    /// <summary>
    /// Servis atamaları (ServiceRequest - Mechanic ilişkisi)
    /// </summary>
    public class ServiceAssignment : BaseEntity
    {
        public int ServiceRequestId { get; set; }
        public int MechanicId { get; set; }
        public DateTime AssignedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public decimal? EstimatedHours { get; set; }
        public decimal? ActualHours { get; set; }
        public string? Notes { get; set; }

        // Navigation Properties
        public virtual ServiceRequest ServiceRequest { get; set; } = null!;
        public virtual Mechanic Mechanic { get; set; } = null!;
    }
}

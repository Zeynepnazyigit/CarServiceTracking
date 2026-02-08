using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.Entities
{
    public class ServiceRequest : BaseEntity
    {
        // Foreign Keys
        public int CustomerId { get; set; }
        public int CarId { get; set; }

        // Servis Bilgileri
        public string ProblemDescription { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? PreferredDate { get; set; }
        public ServiceRequestStatus Status { get; set; } = ServiceRequestStatus.Pending;

        // Admin Alanları
        public decimal? ServicePrice { get; set; }
        public string? AdminNote { get; set; }

        // Navigation Properties
        public virtual Customer Customer { get; set; } = null!;
        public virtual Car Car { get; set; } = null!;
        public virtual ICollection<ServicePart> ServiceParts { get; set; } = new List<ServicePart>();
        public virtual ICollection<ServiceAssignment> ServiceAssignments { get; set; } = new List<ServiceAssignment>();
        public virtual Invoice? Invoice { get; set; }
        public virtual RentalAgreement? RentalAgreement { get; set; }
    }
}

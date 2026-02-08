namespace CarServiceTracking.Core.Entities
{
    /// <summary>
    /// Ustalar/Teknisyenler
    /// </summary>
    public class Mechanic : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Specialization { get; set; } // Motor, Elektrik, Boya, Mekanik
        public decimal HourlyRate { get; set; }
        public DateTime HireDate { get; set; }
        public string? Address { get; set; }
        public string? Notes { get; set; }

        // Hesaplanan Property
        public string FullName => $"{FirstName} {LastName}";

        // Navigation Properties
        public virtual ICollection<ServiceAssignment> ServiceAssignments { get; set; } = new List<ServiceAssignment>();
    }
}

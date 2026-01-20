namespace CarServiceTracking.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? TaxNumber { get; set; }
        public string? CompanyName { get; set; }
        public string? Notes { get; set; }

        // Foreign Keys
        public int? CustomerTypeId { get; set; }

        // Navigation Properties
        public virtual ListItem? CustomerType { get; set; }

        // Diğer navigation'lar kapalı (Vehicle, ServiceRecord henüz yok)
        // public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
        // public virtual ICollection<ServiceRecord> ServiceRecords { get; set; } = new List<ServiceRecord>();
    }
}
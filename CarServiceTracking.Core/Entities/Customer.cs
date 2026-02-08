namespace CarServiceTracking.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
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

        // Hesaplanan Property
        public string FullName => $"{FirstName} {LastName}";

        // Navigation Properties
        public virtual ListItem? CustomerType { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
        public virtual ICollection<CustomerCar> CustomerCars { get; set; } = new List<CustomerCar>();
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();
        public virtual ICollection<ServiceRecord> ServiceRecords { get; set; } = new List<ServiceRecord>();
        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<RentalAgreement> RentalAgreements { get; set; } = new List<RentalAgreement>();
    }
}
namespace CarServiceTracking.UI.Web.ViewModels.Customers
{
    public class CustomerDetailVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? TaxNumber { get; set; }
        public string? CompanyName { get; set; }
        public string? Notes { get; set; }
        public int? CustomerTypeId { get; set; }
        public string? CustomerTypeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int TotalVehicles { get; set; }
        public int TotalServices { get; set; }
        public int CompletedServices { get; set; }
        public int PendingServices { get; set; }
    }
}

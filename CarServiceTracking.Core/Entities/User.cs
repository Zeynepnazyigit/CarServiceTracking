namespace CarServiceTracking.Core.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Customer"; // Admin, Customer
        
        // Foreign Key - Optional (Müşteri ile ilişkilendirme)
        public int? CustomerId { get; set; }

        // Navigation Properties
        public virtual Customer? Customer { get; set; }
    }
}

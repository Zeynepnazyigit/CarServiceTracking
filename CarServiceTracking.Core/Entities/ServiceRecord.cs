namespace CarServiceTracking.Core.Entities
{
    public class ServiceRecord : BaseEntity
    {
        // Genel Bilgi
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime ServiceDate { get; set; }
        public decimal? TotalPrice { get; set; }

        // Foreign Keys
        public int CarId { get; set; }
        public int CustomerId { get; set; }

        // Navigation
        public virtual Car Car { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
    }
}

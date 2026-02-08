namespace CarServiceTracking.Core.Entities
{
    /// <summary>
    /// Serviste kullanılan parçalar (ServiceRequest - Part ilişkisi)
    /// </summary>
    public class ServicePart : BaseEntity
    {
        public int ServiceRequestId { get; set; }
        public int PartId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Notes { get; set; }

        // Navigation Properties
        public virtual ServiceRequest ServiceRequest { get; set; } = null!;
        public virtual Part Part { get; set; } = null!;
    }
}

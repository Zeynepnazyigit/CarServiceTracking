namespace CarServiceTracking.Core.Entities
{
    /// <summary>
    /// Yedek parça stoğu
    /// </summary>
    public class Part : BaseEntity
    {
        public string PartName { get; set; } = string.Empty;
        public string PartCode { get; set; } = string.Empty;
        public string? Category { get; set; }
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public int MinStockLevel { get; set; } = 5;
        public string? Supplier { get; set; }
        public string? SupplierContact { get; set; }

        // Navigation Properties
        public virtual ICollection<ServicePart> ServiceParts { get; set; } = new List<ServicePart>();
    }
}

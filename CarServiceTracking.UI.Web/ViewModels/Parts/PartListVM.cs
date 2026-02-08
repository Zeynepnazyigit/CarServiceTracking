namespace CarServiceTracking.UI.Web.ViewModels.Parts
{
    public class PartListVM
    {
        public int Id { get; set; }
        public string PartCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string? Supplier { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public int MinStockLevel { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// Stok seviyesi minimum seviyenin altında mı?
        /// </summary>
        public bool IsLowStock => StockQuantity < MinStockLevel;
    }
}

namespace CarServiceTracking.UI.Web.Models.ApiModels.PartApiModels
{
    public class PartUpdateApiModel
    {
        public int Id { get; set; }
        public string PartName { get; set; } = string.Empty;
        public string PartCode { get; set; } = string.Empty;
        public string? Category { get; set; }
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public int MinStockLevel { get; set; }
        public string? Supplier { get; set; }
        public string? SupplierContact { get; set; }
        public bool IsActive { get; set; }
    }
}

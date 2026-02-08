namespace CarServiceTracking.UI.Web.ViewModels.Parts
{
    public class PartDropdownVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PartCode { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }

        /// <summary>
        /// Dropdown'da gösterilecek text (Kod - İsim - Stok)
        /// </summary>
        public string DisplayText => $"{PartCode} - {Name} (Stok: {StockQuantity})";
    }
}

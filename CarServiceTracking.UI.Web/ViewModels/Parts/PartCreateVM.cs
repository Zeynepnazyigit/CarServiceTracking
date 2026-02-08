using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.Parts
{
    public class PartCreateVM
    {
        [Required(ErrorMessage = "Parça kodu zorunludur")]
        [StringLength(50, ErrorMessage = "Parça kodu en fazla 50 karakter olabilir")]
        public string PartCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parça adı zorunludur")]
        [StringLength(200, ErrorMessage = "Parça adı en fazla 200 karakter olabilir")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kategori zorunludur")]
        [StringLength(100, ErrorMessage = "Kategori en fazla 100 karakter olabilir")]
        public string Category { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir")]
        public string? Description { get; set; }
    [StringLength(200, ErrorMessage = "Tedarikçi en fazla 200 karakter olabilir")]
    public string? Supplier { get; set; }
        [Required(ErrorMessage = "Birim fiyat zorunludur")]
        [Range(0.01, 999999.99, ErrorMessage = "Birim fiyat 0.01 ile 999999.99 arasında olmalıdır")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Stok miktarı zorunludur")]
        [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı 0 veya daha büyük olmalıdır")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Minimum stok seviyesi zorunludur")]
        [Range(0, int.MaxValue, ErrorMessage = "Minimum stok seviyesi 0 veya daha büyük olmalıdır")]
        public int MinStockLevel { get; set; }

        public bool IsActive { get; set; } = true;
    }
}

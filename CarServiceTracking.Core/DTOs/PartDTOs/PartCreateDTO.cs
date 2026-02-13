using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.Core.DTOs.PartDTOs
{
    public class PartCreateDTO
    {
        [Required(ErrorMessage = "Parça adı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Parça adı en fazla 100 karakter olabilir.")]
        public string PartName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parça kodu zorunludur.")]
        [MaxLength(20, ErrorMessage = "Parça kodu en fazla 20 karakter olabilir.")]
        public string PartCode { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = "Kategori en fazla 50 karakter olabilir.")]
        public string? Category { get; set; }

        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Birim fiyat zorunludur.")]
        [Range(0.01, 999999.99, ErrorMessage = "Birim fiyat 0.01-999999.99 arasında olmalıdır.")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Stok miktarı zorunludur.")]
        [Range(0, 99999, ErrorMessage = "Stok miktarı 0-99999 arasında olmalıdır.")]
        public int StockQuantity { get; set; }

        [Range(0, 99999, ErrorMessage = "Minimum stok seviyesi 0-99999 arasında olmalıdır.")]
        public int MinStockLevel { get; set; } = 5;

        [MaxLength(100, ErrorMessage = "Tedarikçi adı en fazla 100 karakter olabilir.")]
        public string? Supplier { get; set; }

        [MaxLength(100, ErrorMessage = "Tedarikçi iletişim en fazla 100 karakter olabilir.")]
        public string? SupplierContact { get; set; }

        public bool IsActive { get; set; } = true;
    }
}

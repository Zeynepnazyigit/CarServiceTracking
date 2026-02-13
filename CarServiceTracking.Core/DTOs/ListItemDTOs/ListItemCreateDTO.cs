using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.Core.DTOs.ListItemDTOs
{
    public class ListItemCreateDTO
    {
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Ad en fazla 100 karakter olabilir.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Liste tipi zorunludur.")]
        [MaxLength(50, ErrorMessage = "Liste tipi en fazla 50 karakter olabilir.")]
        public string ListType { get; set; } = string.Empty;

        [MaxLength(200, ErrorMessage = "Açıklama en fazla 200 karakter olabilir.")]
        public string? Description { get; set; }

        public int? ParentId { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

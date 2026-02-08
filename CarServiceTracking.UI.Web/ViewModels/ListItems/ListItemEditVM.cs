using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.ListItems
{
    public class ListItemEditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [StringLength(100, ErrorMessage = "Ad en fazla 100 karakter olabilir")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Liste tipi zorunludur")]
        [StringLength(50, ErrorMessage = "Liste tipi en fazla 50 karakter olabilir")]
        public string ListType { get; set; } = string.Empty;

        public int? ParentId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Sıra numarası 0'dan büyük olmalıdır")]
        public int SortOrder { get; set; }

        public bool IsActive { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir")]
        public string? Description { get; set; }
    }
}

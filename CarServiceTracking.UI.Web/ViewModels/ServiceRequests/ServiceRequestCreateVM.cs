using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.ServiceRequests
{
    public class ServiceRequestCreateVM
    {
        [Required(ErrorMessage = "Araç seçimi zorunludur")]
        [Display(Name = "Araç")]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Sorun açıklaması zorunludur")]
        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir")]
        [Display(Name = "Sorun Açıklaması")]
        public string ProblemDescription { get; set; } = string.Empty;

        [Display(Name = "Tercih Edilen Tarih")]
        public DateTime? PreferredDate { get; set; }
    }
}

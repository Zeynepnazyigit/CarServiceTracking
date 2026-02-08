using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.ServiceRequests
{
    public class ServiceRequestUpdateStatusVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Durum seçimi zorunludur")]
        [Display(Name = "Durum")]
        public int Status { get; set; }

        [Display(Name = "Servis Ücreti")]
        [Range(0, 999999, ErrorMessage = "Geçerli bir ücret giriniz")]
        public decimal? ServicePrice { get; set; }

        [StringLength(500, ErrorMessage = "Not en fazla 500 karakter olabilir")]
        [Display(Name = "Yönetici Notu")]
        public string? AdminNote { get; set; }
    }
}

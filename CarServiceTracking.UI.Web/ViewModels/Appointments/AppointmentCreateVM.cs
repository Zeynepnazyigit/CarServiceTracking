using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.Appointments
{
    public class AppointmentCreateVM
    {
        [Required(ErrorMessage = "Müşteri seçimi zorunludur")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Araç seçimi zorunludur")]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Randevu tarihi zorunludur")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Randevu Tarihi")]
        public DateTime AppointmentDate { get; set; } = DateTime.Now.AddDays(1);

        [Required(ErrorMessage = "Zaman dilimi zorunludur")]
        [StringLength(50, ErrorMessage = "Zaman dilimi en fazla 50 karakter olabilir")]
        [Display(Name = "Zaman Dilimi")]
        public string TimeSlot { get; set; } = string.Empty;

        [Required(ErrorMessage = "Talep edilen servis açıklaması zorunludur")]
        [StringLength(500, ErrorMessage = "Servis açıklaması en fazla 500 karakter olabilir")]
        [Display(Name = "Talep Edilen Servis")]
        public string RequestedService { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir")]
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [StringLength(1000, ErrorMessage = "Müşteri notları en fazla 1000 karakter olabilir")]
        [Display(Name = "Müşteri Notları")]
        public string? CustomerNotes { get; set; }
    }
}

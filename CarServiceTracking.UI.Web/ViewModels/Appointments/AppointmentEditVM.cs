using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.Appointments
{
    public class AppointmentEditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Müşteri seçimi zorunludur")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Araç seçimi zorunludur")]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Randevu tarihi zorunludur")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Randevu Tarihi")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Saat aralığı zorunludur")]
        [StringLength(50)]
        [Display(Name = "Saat Aralığı")]
        public string TimeSlot { get; set; } = string.Empty;

        [Required(ErrorMessage = "Talep edilen servis açıklaması zorunludur")]
        [StringLength(500, ErrorMessage = "Servis açıklaması en fazla 500 karakter olabilir")]
        [Display(Name = "Talep Edilen Servis")]
        public string RequestedService { get; set; } = string.Empty;

        [StringLength(1000)]
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [StringLength(1000)]
        [Display(Name = "Müşteri Notları")]
        public string? CustomerNotes { get; set; }

        [StringLength(1000)]
        [Display(Name = "Admin Notları")]
        public string? AdminNotes { get; set; }

        [Required(ErrorMessage = "Durum zorunludur")]
        [StringLength(50)]
        public string Status { get; set; } = "Pending";

        // Display properties
        public string? CustomerName { get; set; }
        public string? CarInfo { get; set; }
    }
}

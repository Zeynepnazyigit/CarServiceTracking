using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.Core.DTOs.AppointmentDTOs
{
    public class AppointmentCreateDTO
    {
        [Required(ErrorMessage = "Müşteri seçimi zorunludur.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Araç seçimi zorunludur.")]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Randevu tarihi zorunludur.")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Saat dilimi zorunludur.")]
        [MaxLength(20, ErrorMessage = "Saat dilimi en fazla 20 karakter olabilir.")]
        public string TimeSlot { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "Hizmet türü en fazla 100 karakter olabilir.")]
        public string? ServiceType { get; set; }

        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string? Description { get; set; }

        [MaxLength(500, ErrorMessage = "Müşteri notu en fazla 500 karakter olabilir.")]
        public string? CustomerNotes { get; set; }
    }
}

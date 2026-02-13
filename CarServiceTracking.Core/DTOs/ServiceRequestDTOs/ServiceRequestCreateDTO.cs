using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.Core.DTOs.ServiceRequestDTOs
{
    public class ServiceRequestCreateDTO
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Araç seçimi zorunludur.")]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Sorun açıklaması zorunludur.")]
        [MaxLength(1000, ErrorMessage = "Sorun açıklaması en fazla 1000 karakter olabilir.")]
        public string ProblemDescription { get; set; } = null!;

        public DateTime? PreferredDate { get; set; }
    }
}

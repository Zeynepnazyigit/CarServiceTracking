using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.Core.DTOs.ServiceAssignmentDTOs
{
    public class ServiceAssignmentCreateDTO
    {
        [Required(ErrorMessage = "Servis talebi zorunludur.")]
        public int ServiceRequestId { get; set; }

        [Required(ErrorMessage = "Teknisyen zorunludur.")]
        public int MechanicId { get; set; }

        [Range(0.1, 999.99, ErrorMessage = "Tahmini saat 0.1-999.99 arasinda olmalidir.")]
        public decimal? EstimatedHours { get; set; }

        [MaxLength(1000, ErrorMessage = "Not en fazla 1000 karakter olabilir.")]
        public string? Notes { get; set; }
    }
}

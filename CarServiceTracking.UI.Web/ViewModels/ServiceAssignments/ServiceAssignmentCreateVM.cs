using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.ServiceAssignments
{
    public class ServiceAssignmentCreateVM
    {
        public int ServiceRequestId { get; set; }

        [Required(ErrorMessage = "Teknisyen seciniz.")]
        public int MechanicId { get; set; }

        [Range(0.1, 999.99, ErrorMessage = "Tahmini saat 0.1-999.99 arasinda olmalidir.")]
        public decimal? EstimatedHours { get; set; }

        [MaxLength(1000)]
        public string? Notes { get; set; }
    }
}

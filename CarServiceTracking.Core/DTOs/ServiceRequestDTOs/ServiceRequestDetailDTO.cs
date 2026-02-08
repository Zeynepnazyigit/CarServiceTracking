using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.DTOs.ServiceRequestDTOs
{
    public class ServiceRequestDetailDTO
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public string? CarName { get; set; }

        public string ProblemDescription { get; set; } = "";

        public DateTime? PreferredDate { get; set; }

        public ServiceRequestStatus Status { get; set; }

        public decimal? ServicePrice { get; set; }

        public string? AdminNote { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

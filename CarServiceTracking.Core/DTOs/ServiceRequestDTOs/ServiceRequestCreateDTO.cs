using System;

namespace CarServiceTracking.Core.DTOs.ServiceRequestDTOs
{
    public class ServiceRequestCreateDTO
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public string ProblemDescription { get; set; } = null!;
        public DateTime? PreferredDate { get; set; }
    }
}

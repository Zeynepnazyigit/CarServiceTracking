using System;

namespace CarServiceTracking.Core.DTOs.ServiceRequestDTOs
{
    public class ServiceRequestListDTO
    {
        public int Id { get; set; }

        public int CarId { get; set; } // 🔥 ŞART

        public string CarName { get; set; } = string.Empty;

        public string ProblemDescription { get; set; } = string.Empty;


        public int Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? PreferredDate { get; set; }
    }
}

using System;

namespace CarServiceTracking.UI.Web.Models.ApiModels.ServiceRequestApiModels
{
    public class ServiceRequestListApiModel
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

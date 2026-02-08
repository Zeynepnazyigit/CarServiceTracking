using System;

namespace CarServiceTracking.UI.Web.Models.ApiModels.ServiceRequestApiModels
{
    public class ServiceRequestCreateApiModel
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public string ProblemDescription { get; set; } = null!;
        public DateTime? PreferredDate { get; set; }
    }
}

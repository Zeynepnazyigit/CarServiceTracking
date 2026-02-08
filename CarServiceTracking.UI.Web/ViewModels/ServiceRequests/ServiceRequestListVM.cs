using System;

namespace CarServiceTracking.UI.Web.ViewModels.ServiceRequests
{
    public class ServiceRequestListVM
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; } = "";
        public string ProblemDescription { get; set; } = "";
        public int Status { get; set; }
        public string StatusText { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime? PreferredDate { get; set; }
    }
}

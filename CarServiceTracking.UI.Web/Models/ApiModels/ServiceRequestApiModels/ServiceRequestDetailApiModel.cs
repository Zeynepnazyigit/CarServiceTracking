using CarServiceTracking.UI.Web.Enums;

namespace CarServiceTracking.UI.Web.Models.ApiModels.ServiceRequestApiModels
{
    public class ServiceRequestDetailApiModel
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

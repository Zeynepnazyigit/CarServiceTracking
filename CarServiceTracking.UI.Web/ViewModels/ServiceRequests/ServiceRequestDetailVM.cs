namespace CarServiceTracking.UI.Web.ViewModels.ServiceRequests
{
    public class ServiceRequestDetailVM
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; } = "";
        public string ProblemDescription { get; set; } = "";
        public DateTime? PreferredDate { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; } = "";
        public decimal? ServicePrice { get; set; }
        public string? AdminNote { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

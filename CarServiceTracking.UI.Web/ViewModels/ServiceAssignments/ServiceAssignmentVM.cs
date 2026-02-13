namespace CarServiceTracking.UI.Web.ViewModels.ServiceAssignments
{
    public class ServiceAssignmentVM
    {
        public int Id { get; set; }
        public int ServiceRequestId { get; set; }
        public int MechanicId { get; set; }
        public string MechanicName { get; set; } = "";
        public string? Specialization { get; set; }
        public DateTime AssignedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public decimal? EstimatedHours { get; set; }
        public decimal? ActualHours { get; set; }
        public string? Notes { get; set; }
    }
}

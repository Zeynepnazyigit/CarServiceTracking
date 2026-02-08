using CarServiceTracking.UI.Web.Enums;

namespace CarServiceTracking.UI.Web.Models.ApiModels.AppointmentApiModels
{
    public class AppointmentUpdateApiModel
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string TimeSlot { get; set; } = string.Empty;
        public AppointmentStatus Status { get; set; }
        public string? ServiceType { get; set; }
        public string? Description { get; set; }
        public string? AdminNotes { get; set; }
    }
}

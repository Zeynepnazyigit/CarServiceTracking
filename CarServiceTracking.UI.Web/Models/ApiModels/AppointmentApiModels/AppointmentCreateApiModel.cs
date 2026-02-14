namespace CarServiceTracking.UI.Web.Models.ApiModels.AppointmentApiModels
{
    public class AppointmentCreateApiModel
    {
        public int CustomerId { get; set; }
        public int? CarId { get; set; }
        public int? CustomerCarId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string TimeSlot { get; set; } = string.Empty;
        public string? ServiceType { get; set; }
        public string? Description { get; set; }
        public string? CustomerNotes { get; set; }
    }
}

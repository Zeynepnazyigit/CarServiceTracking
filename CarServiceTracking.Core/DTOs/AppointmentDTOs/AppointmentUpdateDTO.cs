using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.DTOs.AppointmentDTOs
{
    public class AppointmentUpdateDTO
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

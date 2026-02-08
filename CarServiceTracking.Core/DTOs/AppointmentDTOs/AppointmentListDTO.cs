using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.DTOs.AppointmentDTOs
{
    public class AppointmentListDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int CarId { get; set; }
        public string CarInfo { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string TimeSlot { get; set; } = string.Empty;
        public AppointmentStatus Status { get; set; }
        public string? ServiceType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

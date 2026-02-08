namespace CarServiceTracking.UI.Web.ViewModels.Appointments
{
    public class AppointmentListVM
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int CarId { get; set; }
        public string CarInfo { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
    public string TimeSlot { get; set; } = string.Empty;
        public string RequestedService { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? Notes { get; set; }

        /// <summary>
        /// Randevu tarihi formatlanmış hali (dd.MM.yyyy HH:mm)
        /// </summary>
        public string FormattedDate => AppointmentDate.ToString("dd.MM.yyyy HH:mm");

        /// <summary>
        /// Status badge renk sınıfı
        /// </summary>
        public string StatusBadgeClass => Status switch
        {
            "Pending" => "badge bg-warning",
            "Confirmed" => "badge bg-success",
            "Cancelled" => "badge bg-danger",
            "Completed" => "badge bg-primary",
            _ => "badge bg-secondary"
        };
    }
}

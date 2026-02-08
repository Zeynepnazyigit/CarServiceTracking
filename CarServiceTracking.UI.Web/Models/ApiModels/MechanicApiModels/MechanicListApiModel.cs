namespace CarServiceTracking.UI.Web.Models.ApiModels.MechanicApiModels
{
    public class MechanicListApiModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Specialization { get; set; }
        public string Phone { get; set; } = string.Empty;
        public decimal HourlyRate { get; set; }
        public bool IsAvailable { get; set; }
        public int ActiveAssignments { get; set; }
    }
}

namespace CarServiceTracking.UI.Web.Models.ApiModels.MechanicApiModels
{
    public class MechanicUpdateApiModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Specialization { get; set; }
        public decimal HourlyRate { get; set; }
        public bool IsAvailable { get; set; }
        public string? Notes { get; set; }
    }
}

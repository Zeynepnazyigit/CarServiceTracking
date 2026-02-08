namespace CarServiceTracking.UI.Web.ViewModels.Mechanics
{
    public class MechanicListVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    public string? Email { get; set; }
    public decimal HourlyRate { get; set; }
    public int ActiveAssignments { get; set; }
        public bool IsActive { get; set; }
        /// Tam ad
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";
    }
}

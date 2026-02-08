namespace CarServiceTracking.UI.Web.ViewModels.Mechanics
{
    public class MechanicDropdownVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;

        /// <summary>
        /// Dropdown'da gösterilecek text (Ad Soyad - Uzmanlık)
        /// </summary>
        public string DisplayText => $"{FirstName} {LastName} - {Specialization}";
    }
}

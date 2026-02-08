namespace CarServiceTracking.UI.Web.ViewModels.Rentals
{
    public class RentalVehicleDropdownVM
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal DailyRate { get; set; }

        /// <summary>
        /// Dropdown'da gösterilecek text
        /// </summary>
        public string DisplayText => $"{Brand} {Model} ({Year}) - {PlateNumber} - {DailyRate:C}/gün";
    }
}

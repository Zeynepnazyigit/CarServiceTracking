namespace CarServiceTracking.UI.Web.ViewModels.Rentals
{
    public class RentalAgreementListVM
    {
        public int Id { get; set; }
        public string AgreementNumber { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int RentalVehicleId { get; set; }
        public string VehicleInfo { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartMileage { get; set; }
        public int? EndMileage { get; set; }
        public decimal DailyRate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DepositAmount { get; set; }
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Tarih bilgileri formatlanmış
        /// </summary>
        public string DateRange => $"{StartDate:dd.MM.yyyy} - {EndDate:dd.MM.yyyy}";

        /// <summary>
        /// Status badge sınıfı
        /// </summary>
        public string StatusBadgeClass => Status switch
        {
            "Active" => "badge bg-success",
            "Completed" => "badge bg-primary",
            "Cancelled" => "badge bg-danger",
            _ => "badge bg-secondary"
        };

        /// <summary>
        /// Status Türkçe
        /// </summary>
        public string StatusText => Status switch
        {
            "Active" => "Aktif",
            "Completed" => "Tamamlandı",
            "Cancelled" => "İptal",
            _ => Status
        };
    }
}

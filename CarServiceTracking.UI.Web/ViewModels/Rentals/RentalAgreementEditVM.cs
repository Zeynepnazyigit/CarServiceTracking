using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.Rentals
{
    public class RentalAgreementEditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Sözleşme numarası zorunludur")]
        [StringLength(50)]
        public string AgreementNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Müşteri seçimi zorunludur")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Araç seçimi zorunludur")]
        public int RentalVehicleId { get; set; }

        // Display için
        public string CustomerName { get; set; } = string.Empty;
        public string VehicleInfo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunludur")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Range(0, int.MaxValue)]
        public int? StartMileage { get; set; }

        [Range(0, int.MaxValue)]
        public int? EndMileage { get; set; }

        [Required(ErrorMessage = "Günlük ücret zorunludur")]
        [Range(0.01, 999999.99)]
        public decimal DailyRate { get; set; }

        [Required(ErrorMessage = "Toplam tutar zorunludur")]
        [Range(0.01, 999999.99)]
        public decimal TotalAmount { get; set; }

        [Range(0, 999999.99)]
        public decimal DepositAmount { get; set; }

        [Required(ErrorMessage = "Durum zorunludur")]
        [StringLength(50)]
        public string Status { get; set; } = "Active";

        [StringLength(1000)]
        public string? Notes { get; set; }
    }
}

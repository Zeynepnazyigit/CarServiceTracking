using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.Rentals
{
    /// <summary>
    /// Kiralama oluşturma form ViewModel
    /// </summary>
    public class RentalCreateVM
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Araç seçimi zorunludur")]
        public int VehicleId { get; set; }

        public string VehicleName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur")]
        [DataType(DataType.Date)]
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunludur")]
        [DataType(DataType.Date)]
        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Başlangıç KM 0'dan büyük olmalıdır")]
        [Display(Name = "Başlangıç KM")]
        public int? StartMileage { get; set; }

        [Required(ErrorMessage = "Depozito tutarı zorunludur")]
        [Range(0, 999999, ErrorMessage = "Depozito tutarı 0 ile 999999 arasında olmalıdır")]
        [Display(Name = "Depozito Tutarı")]
        public decimal DepositAmount { get; set; }

        public decimal DailyRate { get; set; }

        [Display(Name = "Notlar")]
        public string? Notes { get; set; }

        /// <summary>
        /// Hesaplanan toplam tutar
        /// </summary>
        public decimal CalculatedTotal
        {
            get
            {
                var days = (EndDate - StartDate).Days;
                return days > 0 ? days * DailyRate : 0;
            }
        }
    }
}

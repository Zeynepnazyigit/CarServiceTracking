using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.UI.Web.ViewModels.Rentals
{
    public class RentalAgreementCreateVM
    {
        /// <summary>
        /// Backend tarafından otomatik üretilir, formda gönderilmez.
        /// </summary>
        public string AgreementNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Müşteri seçimi zorunludur")]
        [Range(1, int.MaxValue, ErrorMessage = "Müşteri seçiniz")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Araç seçimi zorunludur")]
        [Range(1, int.MaxValue, ErrorMessage = "Araç seçiniz")]
        public int RentalVehicleId { get; set; }

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Bitiş tarihi zorunludur")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(7);

        [Required(ErrorMessage = "Başlangıç km zorunludur")]
        [Range(0, int.MaxValue, ErrorMessage = "Geçerli bir km değeri giriniz")]
        public int StartMileage { get; set; }

        [Required(ErrorMessage = "Günlük ücret zorunludur")]
        [Range(0.01, 999999.99)]
        public decimal DailyRate { get; set; }

        /// <summary>
        /// Backend tarafından hesaplanır, formda zorunlu değil.
        /// </summary>
        public decimal TotalAmount { get; set; }

        [Range(0, 999999.99)]
        public decimal DepositAmount { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }
    }
}

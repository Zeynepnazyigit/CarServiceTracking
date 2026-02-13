using System.ComponentModel.DataAnnotations;

namespace CarServiceTracking.Core.DTOs.RentalDTOs
{
    public class RentalAgreementCreateDTO
    {
        [Required(ErrorMessage = "Müşteri seçimi zorunludur.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Kiralık araç seçimi zorunludur.")]
        public int RentalVehicleId { get; set; }

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunludur.")]
        public DateTime EndDate { get; set; }

        [Range(0, 999999, ErrorMessage = "Depozito 0-999999 arasında olmalıdır.")]
        public decimal DepositAmount { get; set; }

        public int? ServiceRequestId { get; set; }

        [Range(0, 2000000, ErrorMessage = "Başlangıç km 0-2.000.000 arasında olmalıdır.")]
        public int StartMileage { get; set; }

        [MaxLength(500, ErrorMessage = "Not en fazla 500 karakter olabilir.")]
        public string? Notes { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.DTOs.RentalDTOs
{
    public class RentalAgreementUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunludur.")]
        public DateTime EndDate { get; set; }

        [Range(0, 999999, ErrorMessage = "Depozito 0-999999 arasında olmalıdır.")]
        public decimal DepositAmount { get; set; }

        [Required(ErrorMessage = "Durum seçimi zorunludur.")]
        public RentalStatus Status { get; set; }

        [Range(0, 2000000, ErrorMessage = "Bitiş km 0-2.000.000 arasında olmalıdır.")]
        public int? EndMileage { get; set; }

        public DateTime? ActualReturnDate { get; set; }

        [MaxLength(500, ErrorMessage = "Not en fazla 500 karakter olabilir.")]
        public string? Notes { get; set; }
    }
}

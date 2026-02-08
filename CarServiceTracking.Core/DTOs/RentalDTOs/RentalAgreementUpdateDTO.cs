using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.DTOs.RentalDTOs
{
    public class RentalAgreementUpdateDTO
    {
        public int Id { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DepositAmount { get; set; }
        public RentalStatus Status { get; set; }
        public int? EndMileage { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public string? Notes { get; set; }
    }
}

using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.DTOs.RentalDTOs
{
    public class RentalAgreementDetailDTO
    {
        public int Id { get; set; }
        public string AgreementNumber { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public int RentalVehicleId { get; set; }
        public string VehicleInfo { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RentalDays { get; set; }
        public decimal DailyRate { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal TotalCost { get; set; }
        public RentalStatus Status { get; set; }
        public int? ServiceRequestId { get; set; }
        public int StartMileage { get; set; }
        public int? EndMileage { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public decimal? LateFee { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

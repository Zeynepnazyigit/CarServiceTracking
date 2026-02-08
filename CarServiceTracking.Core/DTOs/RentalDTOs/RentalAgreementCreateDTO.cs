namespace CarServiceTracking.Core.DTOs.RentalDTOs
{
    public class RentalAgreementCreateDTO
    {
        public int CustomerId { get; set; }
        public int RentalVehicleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DepositAmount { get; set; }
        public int? ServiceRequestId { get; set; }
        public int StartMileage { get; set; }
        public string? Notes { get; set; }
    }
}

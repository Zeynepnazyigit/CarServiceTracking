using CarServiceTracking.UI.Web.Enums;

namespace CarServiceTracking.UI.Web.Models.ApiModels.RentalApiModels
{
    public class RentalAgreementUpdateApiModel
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

using CarServiceTracking.UI.Web.Enums;

namespace CarServiceTracking.UI.Web.Models.ApiModels.RentalApiModels
{
    public class RentalAgreementListApiModel
    {
        public int Id { get; set; }
        public string AgreementNumber { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int RentalVehicleId { get; set; }
        public string VehicleInfo { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RentalDays { get; set; }
        public decimal TotalCost { get; set; }
        public RentalStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

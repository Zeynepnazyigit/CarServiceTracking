using CarServiceTracking.Core.Enums;

namespace CarServiceTracking.Core.Entities
{
    /// <summary>
    /// Kiralama sözleşmeleri (ServiceRequest'e bağlı)
    /// </summary>
    public class RentalAgreement : BaseEntity
    {
        public string AgreementNumber { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public int RentalVehicleId { get; set; }
        public int? ServiceRequestId { get; set; } // Servisi uzun süren araçlar için kiralama
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        
        public decimal DailyRate { get; set; }
        public int TotalDays { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal? LateFee { get; set; }
        
        public RentalStatus Status { get; set; } = RentalStatus.Active;
        
        public int StartMileage { get; set; }
        public int? EndMileage { get; set; }
        
        public string? PickupNotes { get; set; }
        public string? ReturnNotes { get; set; }
        public string? DamageNotes { get; set; }

        // Navigation Properties
        public virtual Customer Customer { get; set; } = null!;
        public virtual RentalVehicle RentalVehicle { get; set; } = null!;
        public virtual ServiceRequest? ServiceRequest { get; set; }
    }
}

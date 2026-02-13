using CarServiceTracking.UI.Web.ViewModels.ServiceRequests;
using CarServiceTracking.UI.Web.ViewModels.Rentals;

namespace CarServiceTracking.UI.Web.ViewModels.Home
{
    public class AdminDashboardVM
    {
        // KPI Kartları
        public int TotalCarCount { get; set; }
        public int TotalCustomerCount { get; set; }
        public int ActiveServiceCount { get; set; }
        public int PendingServiceCount { get; set; }
        public int ActiveRentalCount { get; set; }
        public int LowStockPartCount { get; set; }
        public int TodayAppointmentCount { get; set; }
        public int UnpaidInvoiceCount { get; set; }

        // Son Servis Talepleri (max 5)
        public List<ServiceRequestListVM> RecentServiceRequests { get; set; } = new();

        // Son Kiralamalar (max 5)
        public List<RentalAgreementListVM> RecentRentals { get; set; } = new();

        // Uyarılar
        public int OverdueRentalCount { get; set; }
        public int OverdueInvoiceCount { get; set; }
    }
}

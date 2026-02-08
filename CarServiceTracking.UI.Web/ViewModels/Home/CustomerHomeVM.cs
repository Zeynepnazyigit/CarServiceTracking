using CarServiceTracking.UI.Web.ViewModels.ServiceRequests;
using CarServiceTracking.UI.Web.ViewModels.Appointments;

namespace CarServiceTracking.UI.Web.ViewModels.Home
{
    public class CustomerHomeVM
    {
        // Özet kartlar
        public int RegisteredCarCount { get; set; }
        public int ActiveServiceCount { get; set; }
        public int UpcomingAppointmentCount { get; set; }
        public int UnpaidInvoiceCount { get; set; }

        // Son servis talepleri (max 5)
        public List<ServiceRequestListVM> RecentServiceRequests { get; set; } = new();

        // Yaklaşan randevular (max 3)
        public List<AppointmentListVM> UpcomingAppointments { get; set; } = new();

        // Kiralama bilgisi
        public int ActiveRentalCount { get; set; }
        public string? ActiveRentalInfo { get; set; }
    }
}

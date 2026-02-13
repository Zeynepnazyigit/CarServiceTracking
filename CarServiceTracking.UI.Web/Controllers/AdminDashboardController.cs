using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Home;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminDashboardController : AdminBaseController
    {
        private readonly CarApiService _carApiService;
        private readonly CustomerApiService _customerApiService;
        private readonly ServiceRequestApiService _serviceRequestApiService;
        private readonly RentalApiService _rentalApiService;
        private readonly PartApiService _partApiService;
        private readonly AppointmentApiService _appointmentApiService;
        private readonly InvoiceApiService _invoiceApiService;

        public AdminDashboardController(
            CarApiService carApiService,
            CustomerApiService customerApiService,
            ServiceRequestApiService serviceRequestApiService,
            RentalApiService rentalApiService,
            PartApiService partApiService,
            AppointmentApiService appointmentApiService,
            InvoiceApiService invoiceApiService)
        {
            _carApiService = carApiService;
            _customerApiService = customerApiService;
            _serviceRequestApiService = serviceRequestApiService;
            _rentalApiService = rentalApiService;
            _partApiService = partApiService;
            _appointmentApiService = appointmentApiService;
            _invoiceApiService = invoiceApiService;
        }

        public async Task<IActionResult> Index()
        {
            // Paralel veri çekme (performans için)
            var carsTask = _carApiService.GetAllCarsAsync();
            var customersTask = _customerApiService.GetAllAsync();
            var serviceRequestsTask = _serviceRequestApiService.GetAllAsync();
            var rentalsTask = _rentalApiService.GetAllAgreementsAsync();
            var lowStockTask = _partApiService.GetLowStockAsync();
            var appointmentsTask = _appointmentApiService.GetAllAsync();
            var invoicesTask = _invoiceApiService.GetAllAsync();
            var overdueRentalsTask = _rentalApiService.GetOverdueAgreementsAsync();
            var overdueInvoicesTask = _invoiceApiService.GetOverdueAsync();

            await Task.WhenAll(
                carsTask, customersTask, serviceRequestsTask, rentalsTask,
                lowStockTask, appointmentsTask, invoicesTask,
                overdueRentalsTask, overdueInvoicesTask);

            var cars = await carsTask;
            var customers = await customersTask;
            var serviceRequests = await serviceRequestsTask;
            var rentals = await rentalsTask;
            var lowStockParts = await lowStockTask;
            var appointments = await appointmentsTask;
            var invoices = await invoicesTask;
            var overdueRentals = await overdueRentalsTask;
            var overdueInvoices = await overdueInvoicesTask;

            var model = new AdminDashboardVM
            {
                // KPI Kartları
                TotalCarCount = cars.Count,
                TotalCustomerCount = customers.Count,
                ActiveServiceCount = serviceRequests.Count(r => r.Status == 1),
                PendingServiceCount = serviceRequests.Count(r => r.Status == 0),
                ActiveRentalCount = rentals.Count(r => r.Status == "Active"),
                LowStockPartCount = lowStockParts.Count,
                TodayAppointmentCount = appointments.Count(a => a.AppointmentDate.Date == DateTime.Today),
                UnpaidInvoiceCount = invoices.Count(i => i.PaymentStatus == "Unpaid" || i.PaymentStatus == "Overdue"),

                // Son Servis Talepleri (en yeni 5)
                RecentServiceRequests = serviceRequests
                    .OrderByDescending(r => r.CreatedAt)
                    .Take(5)
                    .ToList(),

                // Son Kiralamalar (en yeni 5)
                RecentRentals = rentals
                    .OrderByDescending(r => r.StartDate)
                    .Take(5)
                    .ToList(),

                // Uyarılar
                OverdueRentalCount = overdueRentals.Count,
                OverdueInvoiceCount = overdueInvoices.Count
            };

            return View(model);
        }
    }
}

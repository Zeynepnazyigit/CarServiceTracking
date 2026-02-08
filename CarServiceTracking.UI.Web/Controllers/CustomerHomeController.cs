using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.ViewModels.Home;
using CarServiceTracking.UI.Web.Services;

namespace CarServiceTracking.UI.Web.Controllers
{
    [Route("Customer/Home")]
    public class CustomerHomeController : CustomerBaseController
    {
        private readonly CustomerCarApiService _customerCarApiService;
        private readonly ServiceRequestApiService _serviceRequestApiService;
        private readonly AppointmentApiService _appointmentApiService;
        private readonly InvoiceApiService _invoiceApiService;
        private readonly RentalApiService _rentalApiService;

        public CustomerHomeController(
            CustomerCarApiService customerCarApiService,
            ServiceRequestApiService serviceRequestApiService,
            AppointmentApiService appointmentApiService,
            InvoiceApiService invoiceApiService,
            RentalApiService rentalApiService)
        {
            _customerCarApiService = customerCarApiService;
            _serviceRequestApiService = serviceRequestApiService;
            _appointmentApiService = appointmentApiService;
            _invoiceApiService = invoiceApiService;
            _rentalApiService = rentalApiService;
        }

        [HttpGet]
        [Route("Index")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId")!.Value;

            // Paralel veri çekme
            var carsTask = _customerCarApiService.GetByCustomerIdAsync(userId);
            var serviceRequestsTask = _serviceRequestApiService.GetAllAsync();
            var appointmentsTask = _appointmentApiService.GetByCustomerIdAsync(userId);
            var invoicesTask = _invoiceApiService.GetByCustomerIdAsync(userId);
            var rentalsTask = _rentalApiService.GetCustomerRentalsAsync(userId);

            await Task.WhenAll(carsTask, serviceRequestsTask, appointmentsTask, invoicesTask, rentalsTask);

            var customerCars = await carsTask;
            var serviceRequests = await serviceRequestsTask;
            var appointments = await appointmentsTask;
            var invoices = await invoicesTask;
            var rentals = await rentalsTask;

            // Aktif servisler (Beklemede=0, İşlemde=1)
            var activeServiceCount = serviceRequests?.Count(s => s.Status == 0 || s.Status == 1) ?? 0;

            // Yaklaşan randevular (Pending veya Confirmed, gelecek tarihli)
            var upcomingAppointments = appointments?
                .Where(a => (a.Status == "Pending" || a.Status == "Confirmed") && a.AppointmentDate >= DateTime.Today)
                .OrderBy(a => a.AppointmentDate)
                .Take(3)
                .ToList() ?? new();

            // Ödenmemiş faturalar
            var unpaidInvoiceCount = invoices?.Count(i => i.PaymentStatus != "Paid") ?? 0;

            // Aktif kiralamalar
            var activeRentals = rentals?.Where(r => r.Status == "Active").ToList() ?? new();
            var activeRentalInfo = activeRentals.Any()
                ? $"{activeRentals.First().VehicleInfo} ({activeRentals.First().DateRange})"
                : null;

            var vm = new CustomerHomeVM
            {
                RegisteredCarCount = customerCars?.Count ?? 0,
                ActiveServiceCount = activeServiceCount,
                UpcomingAppointmentCount = upcomingAppointments.Count,
                UnpaidInvoiceCount = unpaidInvoiceCount,
                RecentServiceRequests = serviceRequests?
                    .OrderByDescending(s => s.CreatedAt)
                    .Take(5)
                    .ToList() ?? new(),
                UpcomingAppointments = upcomingAppointments,
                ActiveRentalCount = activeRentals.Count,
                ActiveRentalInfo = activeRentalInfo
            };

            return View(vm);
        }
    }
}

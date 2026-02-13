using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.ViewModels.Home;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.CustomerCars;
using CarServiceTracking.UI.Web.ViewModels.ServiceRequests;
using CarServiceTracking.UI.Web.ViewModels.Appointments;
using CarServiceTracking.UI.Web.ViewModels.Invoices;
using CarServiceTracking.UI.Web.ViewModels.Rentals;

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
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Auth");

            var customerId = HttpContext.Session.GetInt32("CustomerId") ?? userId.Value;

            List<CustomerCarVM> customerCars = new();
            List<ServiceRequestListVM> serviceRequests = new();
            List<AppointmentListVM> appointments = new();
            List<InvoiceListVM> invoices = new();
            List<CustomerRentalListVM> rentals = new();

            try
            {
                var carsTask = _customerCarApiService.GetByCustomerIdAsync(customerId);
                var srTask = _serviceRequestApiService.GetByCustomerIdAsync(customerId);
                var appTask = _appointmentApiService.GetByCustomerIdAsync(customerId);
                var invTask = _invoiceApiService.GetByCustomerIdAsync(customerId);
                var rentTask = _rentalApiService.GetCustomerRentalsAsync(customerId);

                await Task.WhenAll(carsTask, srTask, appTask, invTask, rentTask);

                customerCars = await carsTask;
                serviceRequests = await srTask;
                appointments = await appTask;
                invoices = await invTask;
                rentals = await rentTask;
            }
            catch
            {
                // API 401 verirse dashboard patlamasın diye yumuşak düşüş
            }

            var activeServiceCount =
                serviceRequests.Count(s => s.Status == 0 || s.Status == 1);

            var upcomingAppointments = appointments
                .Where(a => (a.Status == "Pending" || a.Status == "Confirmed")
                            && a.AppointmentDate >= DateTime.Today)
                .OrderBy(a => a.AppointmentDate)
                .Take(3)
                .ToList();

            // 🔥 DÜZELTİLDİ — artık doğru sayıyor
            var unpaidInvoiceCount =
                invoices.Count(i => i.RemainingAmount > 0);

            var activeRentals =
                rentals.Where(r => r.Status == "Active").ToList();

            var activeRentalInfo = activeRentals.Any()
                ? $"{activeRentals.First().VehicleInfo} ({activeRentals.First().DateRange})"
                : null;

            var vm = new CustomerHomeVM
            {
                RegisteredCarCount = customerCars.Count,
                ActiveServiceCount = activeServiceCount,
                UpcomingAppointmentCount = upcomingAppointments.Count,
                UnpaidInvoiceCount = unpaidInvoiceCount,
                RecentServiceRequests =
                    serviceRequests.OrderByDescending(s => s.CreatedAt).Take(5).ToList(),
                UpcomingAppointments = upcomingAppointments,
                ActiveRentalCount = activeRentals.Count,
                ActiveRentalInfo = activeRentalInfo
            };

            return View(vm);
        }
    }
}
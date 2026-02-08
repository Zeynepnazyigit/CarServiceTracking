using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Appointments;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminAppointmentsController : AdminBaseController
    {
        private readonly AppointmentApiService _appointmentApiService;
        private readonly CustomerApiService _customerApiService;
        private readonly CarApiService _carApiService;

        public AdminAppointmentsController(
            AppointmentApiService appointmentApiService,
            CustomerApiService customerApiService,
            CarApiService carApiService)
        {
            _appointmentApiService = appointmentApiService;
            _customerApiService = customerApiService;
            _carApiService = carApiService;
        }

        // GET: AdminAppointments/Index
        public async Task<IActionResult> Index(string? status)
        {
            List<AppointmentListVM> appointments;

            if (!string.IsNullOrEmpty(status))
            {
                appointments = await _appointmentApiService.GetByStatusAsync(status);
                ViewBag.Status = status;
            }
            else
            {
                appointments = await _appointmentApiService.GetAllAsync();
            }

            return View(appointments);
        }

        // GET: AdminAppointments/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var appointment = await _appointmentApiService.GetByIdAsync(id);
            if (appointment == null)
                return NotFound();

            return View(appointment);
        }

        // GET: AdminAppointments/Create
        public async Task<IActionResult> Create()
        {
            await LoadDropdownsAsync();
            return View();
        }

        // POST: AdminAppointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync();
                return View(model);
            }

            var (success, message) = await _appointmentApiService.CreateAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                await LoadDropdownsAsync();
                return View(model);
            }

            TempData["SuccessMessage"] = "Randevu başarıyla oluşturuldu.";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminAppointments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var appointment = await _appointmentApiService.GetByIdAsync(id);
            if (appointment == null)
                return NotFound();

            var model = new AppointmentEditVM
            {
                Id = appointment.Id,
                CustomerId = appointment.CustomerId,
                CarId = appointment.CarId,
                AppointmentDate = appointment.AppointmentDate,
                TimeSlot = appointment.TimeSlot,
                RequestedService = appointment.RequestedService,
                Description = appointment.Description,
                CustomerNotes = appointment.CustomerNotes,
                AdminNotes = appointment.AdminNotes,
                Status = appointment.Status
            };

            await LoadDropdownsAsync();
            return View(model);
        }

        // POST: AdminAppointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AppointmentEditVM model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync();
                return View(model);
            }

            var (success, message) = await _appointmentApiService.UpdateAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                await LoadDropdownsAsync();
                return View(model);
            }

            TempData["SuccessMessage"] = "Randevu başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        // POST: AdminAppointments/Confirm/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirm(int id)
        {
            var (success, message) = await _appointmentApiService.ConfirmAsync(id);

            if (!success)
            {
                TempData["ErrorMessage"] = message;
            }
            else
            {
                TempData["SuccessMessage"] = "Randevu onaylandı.";
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: AdminAppointments/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id, string cancellationReason)
        {
            var (success, message) = await _appointmentApiService.CancelAsync(id, cancellationReason ?? "İptal edildi");

            if (!success)
            {
                TempData["ErrorMessage"] = message;
            }
            else
            {
                TempData["SuccessMessage"] = "Randevu iptal edildi.";
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: AdminAppointments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var (success, message) = await _appointmentApiService.DeleteAsync(id);

            if (!success)
            {
                TempData["ErrorMessage"] = message;
            }
            else
            {
                TempData["SuccessMessage"] = "Randevu başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task LoadDropdownsAsync()
        {
            var customers = await _customerApiService.GetAllCustomersAsync();
            ViewBag.Customers = new SelectList(customers, "Id", "FullName");

            var cars = await _carApiService.GetAllCarsAsync();
            ViewBag.Cars = new SelectList(cars, "Id", "PlateNumber");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.ServiceRequests;
using CarServiceTracking.UI.Web.ViewModels.ServiceAssignments;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminServiceRequestsController : AdminBaseController
    {
        private readonly ServiceRequestApiService _serviceRequestApiService;
        private readonly CarApiService _carApiService;
        private readonly CustomerApiService _customerApiService;
        private readonly PdfService _pdfService;
        private readonly ServiceAssignmentApiService _serviceAssignmentApiService;
        private readonly MechanicApiService _mechanicApiService;

        public AdminServiceRequestsController(
            ServiceRequestApiService serviceRequestApiService,
            CarApiService carApiService,
            CustomerApiService customerApiService,
            PdfService pdfService,
            ServiceAssignmentApiService serviceAssignmentApiService,
            MechanicApiService mechanicApiService)
        {
            _serviceRequestApiService = serviceRequestApiService;
            _carApiService = carApiService;
            _customerApiService = customerApiService;
            _pdfService = pdfService;
            _serviceAssignmentApiService = serviceAssignmentApiService;
            _mechanicApiService = mechanicApiService;
        }

        // GET: AdminServiceRequests
        public async Task<IActionResult> Index()
        {
            var list = await _serviceRequestApiService.GetAllAsync();
            return View(list);
        }

        // GET: AdminServiceRequests/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _serviceRequestApiService.GetByIdAsync(id);

            if (item == null)
                return NotFound();

            var assignments = await _serviceAssignmentApiService.GetByServiceRequestIdAsync(id);
            ViewBag.Assignments = assignments;

            var mechanics = await _mechanicApiService.GetForDropdownAsync();
            ViewBag.Mechanics = new SelectList(mechanics, "Id", "DisplayText");

            return View(item);
        }

        // POST: AdminServiceRequests/AssignMechanic
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignMechanic(ServiceAssignmentCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Lutfen teknisyen seciniz.";
                return RedirectToAction(nameof(Details), new { id = model.ServiceRequestId });
            }

            var (success, message) = await _serviceAssignmentApiService.AssignAsync(
                model.ServiceRequestId, model);

            if (!success)
                TempData["ErrorMessage"] = message;
            else
                TempData["SuccessMessage"] = message;

            return RedirectToAction(nameof(Details), new { id = model.ServiceRequestId });
        }

        // POST: AdminServiceRequests/RemoveAssignment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveAssignment(int serviceRequestId, int assignmentId)
        {
            var (success, message) = await _serviceAssignmentApiService.RemoveAsync(
                serviceRequestId, assignmentId);

            if (!success)
                TempData["ErrorMessage"] = message;
            else
                TempData["SuccessMessage"] = message;

            return RedirectToAction(nameof(Details), new { id = serviceRequestId });
        }

        // GET: AdminServiceRequests/Create
        public async Task<IActionResult> Create()
        {
            await LoadCarsAsync();
            await LoadCustomersAsync();
            return View();
        }

        // POST: AdminServiceRequests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceRequestCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                await LoadCarsAsync();
                await LoadCustomersAsync();
                return View(model);
            }

            // CustomerId formdan gelecek (model.CustomerId), yoksa session'dan al
            int customerId = model.CustomerId > 0
                ? model.CustomerId
                : HttpContext.Session.GetInt32("CustomerId") ?? 1;

            var success = await _serviceRequestApiService.CreateAsync(model, customerId);

            if (!success)
            {
                ModelState.AddModelError("", "Servis talebi oluşturulurken bir hata oluştu.");
                await LoadCarsAsync();
                return View(model);
            }

            TempData["SuccessMessage"] = "Servis talebi başarıyla oluşturuldu.";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminServiceRequests/UpdateStatus/5
        public async Task<IActionResult> UpdateStatus(int id)
        {
            var item = await _serviceRequestApiService.GetByIdAsync(id);

            if (item == null)
                return NotFound();

            var model = new ServiceRequestUpdateStatusVM
            {
                Id = item.Id,
                Status = item.Status,
                ServicePrice = item.ServicePrice,
                AdminNote = item.AdminNote
            };

            LoadStatusList();
            return View(model);
        }

        // POST: AdminServiceRequests/UpdateStatus/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, ServiceRequestUpdateStatusVM model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                LoadStatusList();
                return View(model);
            }

            var success = await _serviceRequestApiService.UpdateStatusAsync(id, model);

            if (!success)
            {
                ModelState.AddModelError("", "Durum güncellenirken bir hata oluştu.");
                LoadStatusList();
                return View(model);
            }

            TempData["SuccessMessage"] = "Servis durumu başarıyla güncellendi.";
            return RedirectToAction(nameof(Details), new { id });
        }

        // GET: AdminServiceRequests/DownloadPdf/5
        public async Task<IActionResult> DownloadPdf(int id)
        {
            var item = await _serviceRequestApiService.GetByIdAsync(id);
            if (item == null)
            {
                TempData["ErrorMessage"] = "Servis talebi bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            var pdfBytes = _pdfService.GenerateServiceReportPdf(item);
            return File(pdfBytes, "application/pdf", $"ServisRaporu_{item.Id}.pdf");
        }

        // POST: AdminServiceRequests/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _serviceRequestApiService.DeleteAsync(id);

            if (!success)
            {
                TempData["ErrorMessage"] = "Servis talebi silinirken bir hata oluştu.";
            }
            else
            {
                TempData["SuccessMessage"] = "Servis talebi başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }

        // Helper Methods
        private async Task LoadCarsAsync()
        {
            var cars = await _carApiService.GetAllCarsAsync();
            ViewBag.Cars = new SelectList(cars, "Id", "PlateNumber");
        }

        private async Task LoadCustomersAsync()
        {
            var customers = await _customerApiService.GetAllAsync();
            ViewBag.Customers = new SelectList(customers, "Id", "FullName");
        }

        private void LoadStatusList()
        {
            ViewBag.StatusList = new SelectList(new[]
            {
                new { Value = 0, Text = "Beklemede" },
                new { Value = 1, Text = "İşlemde" },
                new { Value = 2, Text = "Tamamlandı" },
                new { Value = 3, Text = "İptal Edildi" }
            }, "Value", "Text");
        }
    }
}

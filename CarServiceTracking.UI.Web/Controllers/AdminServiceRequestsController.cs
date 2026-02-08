using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.ServiceRequests;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminServiceRequestsController : AdminBaseController
    {
        private readonly ServiceRequestApiService _serviceRequestApiService;
        private readonly CarApiService _carApiService;

        public AdminServiceRequestsController(
            ServiceRequestApiService serviceRequestApiService,
            CarApiService carApiService)
        {
            _serviceRequestApiService = serviceRequestApiService;
            _carApiService = carApiService;
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

            return View(item);
        }

        // GET: AdminServiceRequests/Create
        public async Task<IActionResult> Create()
        {
            await LoadCarsAsync();
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
                return View(model);
            }

            // Şu an için sabit customerId (gelecekte login'den alınacak)
            int customerId = 1;

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

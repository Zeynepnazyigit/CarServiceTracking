using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Rentals;

namespace CarServiceTracking.UI.Web.Controllers
{
    /// <summary>
    /// Kiralık araç yönetimi. Conventional routing kullanır: /AdminRentalVehicles/{action}/{id?}
    /// </summary>
    public class AdminRentalVehiclesController : AdminBaseController
    {
        private readonly RentalApiService _rentalApiService;
        private readonly ListItemApiService _listItemApiService;

        public AdminRentalVehiclesController(RentalApiService rentalApiService, ListItemApiService listItemApiService)
        {
            _rentalApiService = rentalApiService;
            _listItemApiService = listItemApiService;
        }

        private async Task LoadFuelAndTransmissionDropdownsAsync()
        {
            try
            {
                var fuelTypes = await _listItemApiService.GetDropdownByTypeAsync("FuelType");
                ViewBag.FuelTypes = new SelectList(fuelTypes ?? new List<CarServiceTracking.UI.Web.ViewModels.ListItems.ListItemDropdownVM>(), "Name", "Name");
                var transmissionTypes = await _listItemApiService.GetDropdownByTypeAsync("TransmissionType");
                ViewBag.TransmissionTypes = new SelectList(transmissionTypes ?? new List<CarServiceTracking.UI.Web.ViewModels.ListItems.ListItemDropdownVM>(), "Name", "Name");
            }
            catch
            {
                ViewBag.FuelTypes = new SelectList(Enumerable.Empty<SelectListItem>());
                ViewBag.TransmissionTypes = new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }

        public async Task<IActionResult> Index()
        {
            var vehicles = await _rentalApiService.GetAllVehiclesAsync();
            return View(vehicles);
        }

        public async Task<IActionResult> Available()
        {
            var vehicles = await _rentalApiService.GetAvailableVehiclesAsync();
            return View(vehicles);
        }

        public async Task<IActionResult> Details(int id)
        {
            var vehicle = await _rentalApiService.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                TempData["ErrorMessage"] = "Bu kiralık araç bulunamadı.";
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadFuelAndTransmissionDropdownsAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RentalVehicleCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                await LoadFuelAndTransmissionDropdownsAsync();
                return View(model);
            }

            var (success, message) = await _rentalApiService.CreateVehicleAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                await LoadFuelAndTransmissionDropdownsAsync();
                return View(model);
            }

            TempData["SuccessMessage"] = "Kiralık araç başarıyla eklendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await _rentalApiService.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                TempData["ErrorMessage"] = "Bu kiralık araç bulunamadı veya silinmiş olabilir.";
                return RedirectToAction(nameof(Index));
            }

            await LoadFuelAndTransmissionDropdownsAsync();

            var model = new RentalVehicleEditVM
            {
                Id = vehicle.Id,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Year = vehicle.Year,
                PlateNumber = vehicle.PlateNumber,
                FuelType = vehicle.FuelType ?? "",
                TransmissionType = vehicle.TransmissionType ?? "",
                Color = vehicle.Color,
                Mileage = vehicle.Mileage,
                DailyRate = vehicle.DailyRate,
                Features = vehicle.Features,
                IsAvailable = vehicle.IsAvailable
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RentalVehicleEditVM model)
        {
            // Geçerli id: önce route, yoksa form'daki model.Id (binding bazen id'yi 0 gönderebiliyor)
            var effectiveId = id > 0 ? id : model.Id;
            if (effectiveId <= 0)
            {
                TempData["ErrorMessage"] = "Geçersiz istek.";
                return RedirectToAction(nameof(Index));
            }
            model.Id = effectiveId;

            // Müsait/Kirada: hidden input "true"/"false" gönderir (Edit view script ile); yoksa false
            var isAvailableStr = Request.Form["IsAvailable"].ToString() ?? "";
            model.IsAvailable = string.Equals(isAvailableStr, "true", StringComparison.OrdinalIgnoreCase);

            if (!ModelState.IsValid)
            {
                await LoadFuelAndTransmissionDropdownsAsync();
                return View(model);
            }

            var (success, message) = await _rentalApiService.UpdateVehicleAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                await LoadFuelAndTransmissionDropdownsAsync();
                return View(model);
            }

            TempData["SuccessMessage"] = "Kiralık araç başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var (success, message) = await _rentalApiService.DeleteVehicleAsync(id);

            if (!success)
            {
                TempData["ErrorMessage"] = message;
            }
            else
            {
                TempData["SuccessMessage"] = "Kiralık araç başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Tüm kiralık araçları müsait (IsAvailable = true) yapar.
        /// Katmanlı mimari: UI → API → Business → Data.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetAllAvailable()
        {
            var (success, message) = await _rentalApiService.SetAllVehiclesAvailableAsync();
            if (!success)
                TempData["ErrorMessage"] = message;
            else
                TempData["SuccessMessage"] = message;
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Rentals;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminRentalVehiclesController : AdminBaseController
    {
        private readonly RentalApiService _rentalApiService;

        public AdminRentalVehiclesController(RentalApiService rentalApiService)
        {
            _rentalApiService = rentalApiService;
        }

        // GET: AdminRentalVehicles/Index
        public async Task<IActionResult> Index()
        {
            var vehicles = await _rentalApiService.GetAllVehiclesAsync();
            return View(vehicles);
        }

        // GET: AdminRentalVehicles/Available
        public async Task<IActionResult> Available()
        {
            var vehicles = await _rentalApiService.GetAvailableVehiclesAsync();
            return View(vehicles);
        }

        // GET: AdminRentalVehicles/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var vehicle = await _rentalApiService.GetVehicleByIdAsync(id);
            if (vehicle == null)
                return NotFound();

            return View(vehicle);
        }

        // GET: AdminRentalVehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminRentalVehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RentalVehicleCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message) = await _rentalApiService.CreateVehicleAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                return View(model);
            }

            TempData["SuccessMessage"] = "Kiralık araç başarıyla eklendi.";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminRentalVehicles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await _rentalApiService.GetVehicleByIdAsync(id);
            if (vehicle == null)
                return NotFound();

            var model = new RentalVehicleEditVM
            {
                Id = vehicle.Id,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Year = vehicle.Year,
                PlateNumber = vehicle.PlateNumber,
                FuelType = vehicle.FuelType,
                TransmissionType = vehicle.TransmissionType,
                Color = vehicle.Color,
                Mileage = vehicle.Mileage,
                DailyRate = vehicle.DailyRate,
                Features = vehicle.Features,
                IsAvailable = vehicle.IsAvailable
            };

            return View(model);
        }

        // POST: AdminRentalVehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RentalVehicleEditVM model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message) = await _rentalApiService.UpdateVehicleAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                return View(model);
            }

            TempData["SuccessMessage"] = "Kiralık araç başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        // POST: AdminRentalVehicles/Delete/5
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
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Cars;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminCarsController : AdminBaseController
    {
        private readonly CarApiService _carApiService;
        private readonly CustomerApiService _customerApiService;
        private readonly ListItemApiService _listItemApiService;

        public AdminCarsController(
            CarApiService carApiService,
            CustomerApiService customerApiService,
            ListItemApiService listItemApiService)
        {
            _carApiService = carApiService;
            _customerApiService = customerApiService;
            _listItemApiService = listItemApiService;
        }

        // GET: AdminCars/Index
        public async Task<IActionResult> Index(string? search)
        {
            var cars = await _carApiService.GetAllCarsAsync(search);
            ViewBag.SearchTerm = search;
            return View(cars);
        }

        // GET: AdminCars/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var car = await _carApiService.GetCarByIdAsync(id);
            if (car == null)
                return NotFound();

            return View(car);
        }

        // GET: AdminCars/Create
        public async Task<IActionResult> Create()
        {
            await LoadDropdownsAsync();
            return View();
        }

        // POST: AdminCars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync();
                return View(model);
            }

            var success = await _carApiService.CreateCarAsync(model);
            
            if (!success)
            {
                ModelState.AddModelError("", "Araç eklenirken bir hata oluştu.");
                await LoadDropdownsAsync();
                return View(model);
            }

            TempData["SuccessMessage"] = "Araç başarıyla eklendi.";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminCars/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carApiService.GetCarByIdAsync(id);
            if (car == null)
                return NotFound();

            var model = new CarUpdateVM
            {
                Id = car.Id,
                PlateNumber = car.PlateNumber,
                Brand = car.Brand,
                CarModel = car.Model,
                Year = car.Year,
                Color = car.Color,
                ChassisNumber = car.ChassisNumber,
                Mileage = car.Mileage,
                EngineNumber = car.EngineNumber,
                Notes = car.Notes,
                CustomerId = car.CustomerId,
                FuelTypeId = car.FuelTypeId,
                TransmissionTypeId = car.TransmissionTypeId,
                CarTypeId = car.CarTypeId
            };

            await LoadDropdownsAsync();

            return View(model);
        }

        // POST: AdminCars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarUpdateVM model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync();
                return View(model);
            }

            var success = await _carApiService.UpdateCarAsync(model);
            
            if (!success)
            {
                ModelState.AddModelError("", "Araç güncellenirken bir hata oluştu.");
                await LoadDropdownsAsync();
                return View(model);
            }

            TempData["SuccessMessage"] = "Araç başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        // POST: AdminCars/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _carApiService.DeleteCarAsync(id);
            
            if (!success)
            {
                TempData["ErrorMessage"] = "Araç silinirken bir hata oluştu.";
            }
            else
            {
                TempData["SuccessMessage"] = "Araç başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }

        // Private Helper: Dropdown'ları yükle
        private async Task LoadDropdownsAsync()
        {
            // Müşteriler
            var customers = await _customerApiService.GetAllCustomersAsync();
            ViewBag.Customers = new SelectList(customers, "Id", "FullName");

            // Yakıt Tipleri
            var fuelTypes = await _listItemApiService.GetDropdownByTypeAsync("FuelType");
            ViewBag.FuelTypes = new SelectList(fuelTypes, "Id", "Name");

            // Şanzıman Tipleri
            var transmissionTypes = await _listItemApiService.GetDropdownByTypeAsync("TransmissionType");
            ViewBag.TransmissionTypes = new SelectList(transmissionTypes, "Id", "Name");

            // Araç Tipleri
            var carTypes = await _listItemApiService.GetDropdownByTypeAsync("CarType");
            ViewBag.CarTypes = new SelectList(carTypes, "Id", "Name");
        }
    }
}

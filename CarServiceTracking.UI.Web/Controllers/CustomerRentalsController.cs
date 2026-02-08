using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Rentals;

namespace CarServiceTracking.UI.Web.Controllers
{
    [Route("Customer/Rentals")]
    public class CustomerRentalsController : CustomerBaseController
    {
        private readonly RentalApiService _rentalApiService;

        public CustomerRentalsController(RentalApiService rentalApiService)
        {
            _rentalApiService = rentalApiService;
        }

        // KİRALAMA LİSTESİ
        [HttpGet]
        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId")!.Value;
            var rentals = await _rentalApiService.GetCustomerRentalsAsync(userId);
            
            return View(rentals ?? new List<CustomerRentalListVM>());
        }

        // KİRALAMA OLUŞTURMA SAYFASI
        [HttpGet]
        [Route("Create")]
        public async Task<IActionResult> Create(int carId)
        {
            if (carId <= 0)
                return RedirectToAction("Index", "CustomerCarsList");

            var vehicleDetail = await _rentalApiService.GetVehicleDetailAsync(carId);
            if (vehicleDetail == null)
            {
                TempData["Error"] = "Araç bulunamadı.";
                return RedirectToAction("Index", "CustomerCarsList");
            }

            var model = new RentalCreateVM
            {
                VehicleId = carId,
                VehicleName = $"{vehicleDetail.Brand} {vehicleDetail.Model}",
                DailyRate = vehicleDetail.DailyRate,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1)
            };

            return View(model);
        }

        // KİRALAMA OLUŞTUR - POST
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RentalCreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userId = HttpContext.Session.GetInt32("UserId")!.Value;
            model.CustomerId = userId;

            var result = await _rentalApiService.CreateRentalAsync(model);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View(model);
            }

            TempData["Success"] = "Kiralama işlemi başarıyla oluşturuldu!";
            return RedirectToAction(nameof(Success));
        }

        // KİRALAMA DETAY
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var rental = await _rentalApiService.GetRentalDetailAsync(id);
            if (rental == null)
            {
                TempData["Error"] = "Kiralama bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            return View(rental);
        }

        // KİRALAMA BAŞARILI
        [HttpGet]
        [Route("Success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}

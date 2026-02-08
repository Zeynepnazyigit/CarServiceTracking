using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;

namespace CarServiceTracking.UI.Web.Controllers
{
    [Route("Customer/CarsList")]
    public class CustomerCarsListController : CustomerBaseController
    {
        private readonly RentalApiService _rentalApiService;

        public CustomerCarsListController(RentalApiService rentalApiService)
        {
            _rentalApiService = rentalApiService;
        }

        [HttpGet]
        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            // Müşteri için uygun geçici araçları göster
            var cars = await _rentalApiService.GetAvailableVehiclesAsync();
            return View(cars);
        }

        [HttpGet]
        [Route("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var vehicle = await _rentalApiService.GetVehicleDetailAsync(id);
            if (vehicle == null)
            {
                TempData["Error"] = "Araç bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);
        }
    }
}

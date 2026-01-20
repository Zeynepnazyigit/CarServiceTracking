using CarServiceTracking.UI.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarApiService _carApiService;

        public CarsController(CarApiService carApiService)
        {
            _carApiService = carApiService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _carApiService.GetAllCarsAsync();
            return View(cars);
        }
    }
}

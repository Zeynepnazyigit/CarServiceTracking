using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.CustomerCars;

namespace CarServiceTracking.UI.Web.Controllers
{
    [Route("Customer/Cars")]
    public class CustomerCarsController : CustomerBaseController
    {
        private readonly CustomerCarApiService _api;

        public CustomerCarsController(CustomerCarApiService api)
        {
            _api = api;
        }

        // LIST
        [HttpGet]
        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId")!.Value;
            var cars = await _api.GetByCustomerIdAsync(userId);
            return View(cars);
        }

        // DETAIL
        [HttpGet]
        [Route("Detail/{id:int}")]
        public async Task<IActionResult> Detail(int id)
        {
            var car = await _api.GetByIdAsync(id);
            if (car == null)
                return RedirectToAction(nameof(Index));

            return View(car);
        }

        // CREATE - GET
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            var model = new CustomerCarCreateVM
            {
                CustomerId = HttpContext.Session.GetInt32("UserId")!.Value,
                Year = DateTime.Now.Year
            };
            return View(model);
        }

        // CREATE - POST
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCarCreateVM model)
        {
            if (model == null)
            {
                ModelState.AddModelError("", "❌ Model NULL - Form binding başarısız olmuş!");
                return View(new CustomerCarCreateVM 
                { 
                    CustomerId = HttpContext.Session.GetInt32("UserId") ?? 0,
                    Year = DateTime.Now.Year
                });
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.CustomerId = HttpContext.Session.GetInt32("UserId")!.Value;

            var success = await _api.CreateAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", "❌ Araç eklenemedi. API hata döndü.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

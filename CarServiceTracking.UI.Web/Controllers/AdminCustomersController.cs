using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Customers;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminCustomersController : AdminBaseController
    {
        private readonly CustomerApiService _customerApiService;

        public AdminCustomersController(CustomerApiService customerApiService)
        {
            _customerApiService = customerApiService;
        }

        // GET: AdminCustomers
        public async Task<IActionResult> Index()
        {
            var customers = await _customerApiService.GetAllAsync();
            ViewBag.TotalCount = customers.Count; // Aktif müşteri sayısı
            return View(customers);
        }

        // GET: AdminCustomers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var customer = await _customerApiService.GetByIdAsync(id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        // GET: AdminCustomers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminCustomers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await _customerApiService.CreateAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", "Müşteri oluşturulurken bir hata oluştu.");
                return View(model);
            }

            TempData["SuccessMessage"] = "Müşteri başarıyla oluşturuldu.";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminCustomers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerApiService.GetByIdAsync(id);

            if (customer == null)
                return NotFound();

            var model = new CustomerUpdateVM
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                City = customer.City,
                Country = customer.Country,
                PostalCode = customer.PostalCode,
                TaxNumber = customer.TaxNumber,
                CompanyName = customer.CompanyName,
                Notes = customer.Notes,
                CustomerTypeId = customer.CustomerTypeId,
                IsActive = customer.IsActive
            };

            return View(model);
        }

        // POST: AdminCustomers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerUpdateVM model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await _customerApiService.UpdateAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", "Müşteri güncellenirken bir hata oluştu.");
                return View(model);
            }

            TempData["SuccessMessage"] = "Müşteri başarıyla güncellendi.";
            return RedirectToAction(nameof(Details), new { id });
        }

        // POST: AdminCustomers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _customerApiService.DeleteAsync(id);

            if (!success)
            {
                TempData["ErrorMessage"] = "Müşteri silinirken bir hata oluştu.";
            }
            else
            {
                TempData["SuccessMessage"] = "Müşteri başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

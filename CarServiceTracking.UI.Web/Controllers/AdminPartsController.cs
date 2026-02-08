using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Parts;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminPartsController : AdminBaseController
    {
        private readonly PartApiService _partApiService;

        public AdminPartsController(PartApiService partApiService)
        {
            _partApiService = partApiService;
        }

        // GET: AdminParts/Index
        public async Task<IActionResult> Index(string? category)
        {
            List<PartListVM> parts;

            if (!string.IsNullOrEmpty(category))
            {
                parts = await _partApiService.GetByCategoryAsync(category);
                ViewBag.Category = category;
            }
            else
            {
                parts = await _partApiService.GetAllAsync();
            }

            return View(parts);
        }

        // GET: AdminParts/LowStock
        public async Task<IActionResult> LowStock()
        {
            var parts = await _partApiService.GetLowStockAsync();
            return View(parts);
        }

        // GET: AdminParts/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var part = await _partApiService.GetByIdAsync(id);
            if (part == null)
                return NotFound();

            return View(part);
        }

        // GET: AdminParts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminParts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PartCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message) = await _partApiService.CreateAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                return View(model);
            }

            TempData["SuccessMessage"] = "Parça başarıyla eklendi.";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminParts/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var part = await _partApiService.GetByIdAsync(id);
            if (part == null)
                return NotFound();

            var model = new PartEditVM
            {
                Id = part.Id,
                Name = part.Name,
                PartCode = part.PartCode,
                Category = part.Category,
                UnitPrice = part.UnitPrice,
                StockQuantity = part.StockQuantity,
                MinStockLevel = part.MinStockLevel,
                Supplier = part.Supplier,
                Description = part.Description,
                IsActive = part.IsActive
            };

            return View(model);
        }

        // POST: AdminParts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PartEditVM model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message) = await _partApiService.UpdateAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                return View(model);
            }

            TempData["SuccessMessage"] = "Parça başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        // POST: AdminParts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var (success, message) = await _partApiService.DeleteAsync(id);

            if (!success)
            {
                TempData["ErrorMessage"] = message;
            }
            else
            {
                TempData["SuccessMessage"] = "Parça başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

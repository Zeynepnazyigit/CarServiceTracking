using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Mechanics;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminMechanicsController : AdminBaseController
    {
        private readonly MechanicApiService _mechanicApiService;

        public AdminMechanicsController(MechanicApiService mechanicApiService)
        {
            _mechanicApiService = mechanicApiService;
        }

        // GET: AdminMechanics/Index
        public async Task<IActionResult> Index(string? specialization)
        {
            List<MechanicListVM> mechanics;

            if (!string.IsNullOrEmpty(specialization))
            {
                mechanics = await _mechanicApiService.GetBySpecializationAsync(specialization);
                ViewBag.Specialization = specialization;
            }
            else
            {
                mechanics = await _mechanicApiService.GetAllAsync();
            }

            return View(mechanics);
        }

        // GET: AdminMechanics/Available
        public async Task<IActionResult> Available()
        {
            var mechanics = await _mechanicApiService.GetAvailableAsync();
            return View(mechanics);
        }

        // GET: AdminMechanics/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var mechanic = await _mechanicApiService.GetByIdAsync(id);
            if (mechanic == null)
                return NotFound();

            return View(mechanic);
        }

        // GET: AdminMechanics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminMechanics/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MechanicCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message) = await _mechanicApiService.CreateAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                return View(model);
            }

            TempData["SuccessMessage"] = "Teknisyen başarıyla eklendi.";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminMechanics/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var mechanic = await _mechanicApiService.GetByIdAsync(id);
            if (mechanic == null)
                return NotFound();

            var model = new MechanicEditVM
            {
                Id = mechanic.Id,
                FirstName = mechanic.FirstName,
                LastName = mechanic.LastName,
                Email = mechanic.Email,
                PhoneNumber = mechanic.PhoneNumber,
                Specialization = mechanic.Specialization,
                HireDate = mechanic.HireDate,
                HourlyRate = mechanic.HourlyRate,
                IsActive = mechanic.IsActive
            };

            return View(model);
        }

        // POST: AdminMechanics/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MechanicEditVM model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message) = await _mechanicApiService.UpdateAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                return View(model);
            }

            TempData["SuccessMessage"] = "Teknisyen başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        // POST: AdminMechanics/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var (success, message) = await _mechanicApiService.DeleteAsync(id);

            if (!success)
            {
                TempData["ErrorMessage"] = message;
            }
            else
            {
                TempData["SuccessMessage"] = "Teknisyen başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

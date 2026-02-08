using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.ListItems;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminListItemsController : AdminBaseController
    {
        private readonly ListItemApiService _listItemApiService;

        public AdminListItemsController(ListItemApiService listItemApiService)
        {
            _listItemApiService = listItemApiService;
        }

        // GET: AdminListItems/Index
        public async Task<IActionResult> Index()
        {
            var listItems = await _listItemApiService.GetAllAsync();
            return View(listItems);
        }

        // GET: AdminListItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminListItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ListItemCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message) = await _listItemApiService.CreateAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                return View(model);
            }

            TempData["SuccessMessage"] = "Liste öğesi başarıyla eklendi.";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminListItems/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var listItem = await _listItemApiService.GetByIdAsync(id);
            if (listItem == null)
                return NotFound();

            return View(listItem);
        }

        // POST: AdminListItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ListItemEditVM model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message) = await _listItemApiService.UpdateAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                return View(model);
            }

            TempData["SuccessMessage"] = "Liste öğesi başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        // POST: AdminListItems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var (success, message) = await _listItemApiService.DeleteAsync(id);

            if (!success)
            {
                TempData["ErrorMessage"] = message;
            }
            else
            {
                TempData["SuccessMessage"] = "Liste öğesi başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

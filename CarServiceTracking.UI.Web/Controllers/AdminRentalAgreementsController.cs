using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Rentals;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminRentalAgreementsController : AdminBaseController
    {
        private readonly RentalApiService _rentalApiService;
        private readonly CustomerApiService _customerApiService;

        public AdminRentalAgreementsController(
            RentalApiService rentalApiService,
            CustomerApiService customerApiService)
        {
            _rentalApiService = rentalApiService;
            _customerApiService = customerApiService;
        }

        // GET: AdminRentalAgreements/Index
        public async Task<IActionResult> Index()
        {
            var agreements = await _rentalApiService.GetAllAgreementsAsync();
            return View(agreements);
        }

        // GET: AdminRentalAgreements/Active
        public async Task<IActionResult> Active()
        {
            var agreements = await _rentalApiService.GetActiveAgreementsAsync();
            return View(agreements);
        }

        // GET: AdminRentalAgreements/Overdue
        public async Task<IActionResult> Overdue()
        {
            var agreements = await _rentalApiService.GetOverdueAgreementsAsync();
            return View(agreements);
        }

        // GET: AdminRentalAgreements/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var agreement = await _rentalApiService.GetAgreementByIdAsync(id);
            if (agreement == null)
                return NotFound();

            return View(agreement);
        }

        // GET: AdminRentalAgreements/Create
        public async Task<IActionResult> Create()
        {
            await LoadDropdownsAsync();
            return View();
        }

        // POST: AdminRentalAgreements/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RentalAgreementCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync();
                return View(model);
            }

            var (success, message) = await _rentalApiService.CreateAgreementAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                await LoadDropdownsAsync();
                return View(model);
            }

            TempData["SuccessMessage"] = "Kiralama sözleşmesi başarıyla oluşturuldu.";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminRentalAgreements/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var agreement = await _rentalApiService.GetAgreementByIdAsync(id);
            if (agreement == null)
                return NotFound();

            var model = new RentalAgreementEditVM
            {
                Id = agreement.Id,
                EndDate = agreement.EndDate,
                DepositAmount = agreement.DepositAmount,
                Status = agreement.Status,
                EndMileage = agreement.EndMileage,
                Notes = agreement.Notes
            };

            return View(model);
        }

        // POST: AdminRentalAgreements/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RentalAgreementEditVM model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message) = await _rentalApiService.UpdateAgreementAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                return View(model);
            }

            TempData["SuccessMessage"] = "Kiralama sözleşmesi başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        // POST: AdminRentalAgreements/Complete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Complete(int id, int endMileage)
        {
            var (success, message) = await _rentalApiService.CompleteAgreementAsync(id, endMileage, DateTime.Now);

            if (!success)
            {
                TempData["ErrorMessage"] = message;
            }
            else
            {
                TempData["SuccessMessage"] = "Kiralama tamamlandı.";
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: AdminRentalAgreements/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var (success, message) = await _rentalApiService.DeleteAgreementAsync(id);

            if (!success)
            {
                TempData["ErrorMessage"] = message;
            }
            else
            {
                TempData["SuccessMessage"] = "Kiralama sözleşmesi başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task LoadDropdownsAsync()
        {
            var customers = await _customerApiService.GetAllCustomersAsync();
            ViewBag.Customers = new SelectList(customers, "Id", "FullName");

            var vehicles = await _rentalApiService.GetVehiclesForDropdownAsync();
            ViewBag.Vehicles = new SelectList(vehicles, "Id", "DisplayName");
        }
    }
}

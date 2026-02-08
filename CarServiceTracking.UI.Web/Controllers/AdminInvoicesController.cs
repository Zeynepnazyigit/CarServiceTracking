using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Invoices;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminInvoicesController : AdminBaseController
    {
        private readonly InvoiceApiService _invoiceApiService;

        public AdminInvoicesController(InvoiceApiService invoiceApiService)
        {
            _invoiceApiService = invoiceApiService;
        }

        // GET: AdminInvoices/Index
        public async Task<IActionResult> Index(string? status)
        {
            List<InvoiceListVM> invoices;

            if (!string.IsNullOrEmpty(status))
            {
                invoices = await _invoiceApiService.GetByStatusAsync(status);
                ViewBag.Status = status;
            }
            else
            {
                invoices = await _invoiceApiService.GetAllAsync();
            }

            return View(invoices);
        }

        // GET: AdminInvoices/Overdue
        public async Task<IActionResult> Overdue()
        {
            var invoices = await _invoiceApiService.GetOverdueAsync();
            return View(invoices);
        }

        // GET: AdminInvoices/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var invoice = await _invoiceApiService.GetByIdAsync(id);
            if (invoice == null)
                return NotFound();

            return View(invoice);
        }

        // GET: AdminInvoices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminInvoices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message, invoiceId) = await _invoiceApiService.CreateFromServiceRequestAsync(model.ServiceRequestId);

            if (!success)
            {
                ModelState.AddModelError("", message);
                return View(model);
            }

            TempData["SuccessMessage"] = "Fatura başarıyla oluşturuldu.";
            return RedirectToAction(nameof(Details), new { id = invoiceId });
        }

        // GET: AdminInvoices/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var invoice = await _invoiceApiService.GetByIdAsync(id);
            if (invoice == null)
                return NotFound();

            var model = new InvoiceEditVM
            {
                Id = invoice.Id,
                DueDate = invoice.DueDate,
                Notes = invoice.Notes
            };

            return View(model);
        }

        // POST: AdminInvoices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InvoiceEditVM model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message) = await _invoiceApiService.UpdateAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                return View(model);
            }

            TempData["SuccessMessage"] = "Fatura başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        // POST: AdminInvoices/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var (success, message) = await _invoiceApiService.DeleteAsync(id);

            if (!success)
            {
                TempData["ErrorMessage"] = message;
            }
            else
            {
                TempData["SuccessMessage"] = "Fatura başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

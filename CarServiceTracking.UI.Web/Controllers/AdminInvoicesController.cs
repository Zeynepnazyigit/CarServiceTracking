using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Invoices;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminInvoicesController : AdminBaseController
    {
        private readonly InvoiceApiService _invoiceApiService;
        private readonly PdfService _pdfService;

        public AdminInvoicesController(
            InvoiceApiService invoiceApiService,
            PdfService pdfService)
        {
            _invoiceApiService = invoiceApiService;
            _pdfService = pdfService;
        }

        // =========================
        // INDEX
        // =========================
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

        // =========================
        // OVERDUE
        // =========================
        public async Task<IActionResult> Overdue()
        {
            var invoices = await _invoiceApiService.GetOverdueAsync();
            return View(invoices);
        }

        // =========================
        // DETAILS
        // =========================
        public async Task<IActionResult> Details(int id)
        {
            var invoice = await _invoiceApiService.GetByIdAsync(id);
            if (invoice == null)
                return NotFound();

            return View(invoice);
        }

        // =========================
        // CREATE (GET)
        // =========================
        public IActionResult Create()
        {
            return View(new InvoiceCreateVM());
        }

        // =========================
        // CREATE (POST) — DOĞRU YOL
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceCreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result =
                await _invoiceApiService.CreateFromServiceRequestAsync(model.ServiceRequestId, model.ReplaceIfExists);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View(model);
            }

            TempData["SuccessMessage"] = "Fatura başarıyla oluşturuldu.";

            return RedirectToAction(nameof(Details), new { id = result.Data.Id });
        }

        // =========================
        // EDIT (GET)
        // =========================
        public async Task<IActionResult> Edit(int id)
        {
            var invoice = await _invoiceApiService.GetByIdAsync(id);
            if (invoice == null)
                return NotFound();

            return View(invoice);
        }

        // =========================
        // EDIT (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InvoiceEditVM model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            var result = await _invoiceApiService.UpdateAsync(model);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View(model);
            }

            TempData["SuccessMessage"] = "Fatura başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        // =========================
        // PDF
        // =========================
        public async Task<IActionResult> DownloadPdf(int id)
        {
            var invoice = await _invoiceApiService.GetByIdForPdfAsync(id);
            if (invoice == null)
            {
                TempData["ErrorMessage"] = "Fatura bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            var pdfBytes = _pdfService.GenerateInvoicePdf(invoice);
            return File(pdfBytes, "application/pdf", $"Fatura_{invoice.InvoiceNumber}.pdf");
        }

        // =========================
        // DELETE
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _invoiceApiService.DeleteAsync(id);

            if (!result.Success)
                TempData["ErrorMessage"] = result.Message;
            else
                TempData["SuccessMessage"] = "Fatura başarıyla silindi.";

            return RedirectToAction(nameof(Index));
        }
    }
}
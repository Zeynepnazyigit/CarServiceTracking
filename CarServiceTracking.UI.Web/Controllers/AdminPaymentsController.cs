using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Payments;

namespace CarServiceTracking.UI.Web.Controllers
{
    public class AdminPaymentsController : AdminBaseController
    {
        private readonly PaymentApiService _paymentApiService;
        private readonly PdfService _pdfService;

        public AdminPaymentsController(PaymentApiService paymentApiService, PdfService pdfService)
        {
            _paymentApiService = paymentApiService;
            _pdfService = pdfService;
        }

        // GET: AdminPayments/Index
        public async Task<IActionResult> Index(string? method)
        {
            List<PaymentListVM> payments;

            if (!string.IsNullOrEmpty(method))
            {
                payments = await _paymentApiService.GetByMethodAsync(method);
                ViewBag.Method = method;
            }
            else
            {
                payments = await _paymentApiService.GetAllAsync();
            }

            return View(payments);
        }

        // GET: AdminPayments/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var payment = await _paymentApiService.GetByIdAsync(id);
            if (payment == null)
                return NotFound();

            return View(payment);
        }

        // GET: AdminPayments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminPayments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message) = await _paymentApiService.CreateAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                return View(model);
            }

            TempData["SuccessMessage"] = "Ödeme başarıyla kaydedildi.";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminPayments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var payment = await _paymentApiService.GetByIdAsync(id);
            if (payment == null)
                return NotFound();

            var model = new PaymentEditVM
            {
                Id = payment.Id,
                InvoiceId = payment.InvoiceId,
                PaymentDate = payment.PaymentDate,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                TransactionId = payment.TransactionId,
                Notes = payment.Notes
            };

            return View(model);
        }

        // POST: AdminPayments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PaymentEditVM model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message) = await _paymentApiService.UpdateAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", message);
                return View(model);
            }

            TempData["SuccessMessage"] = "Ödeme başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminPayments/DownloadPdf/5
        public async Task<IActionResult> DownloadPdf(int id)
        {
            var payment = await _paymentApiService.GetByIdAsync(id);
            if (payment == null)
            {
                TempData["ErrorMessage"] = "Ödeme bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            var pdfBytes = _pdfService.GeneratePaymentReceiptPdf(payment);
            return File(pdfBytes, "application/pdf", $"OdemeMakbuzu_{payment.Id}.pdf");
        }

        // POST: AdminPayments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var (success, message) = await _paymentApiService.DeleteAsync(id);

            if (!success)
            {
                TempData["ErrorMessage"] = message;
            }
            else
            {
                TempData["SuccessMessage"] = "Ödeme başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

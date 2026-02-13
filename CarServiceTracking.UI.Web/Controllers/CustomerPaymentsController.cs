using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Payments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarServiceTracking.UI.Web.Controllers
{
    [Route("Customer/Payments")]
    public class CustomerPaymentsController : CustomerBaseController
    {
        private readonly PaymentApiService _paymentApiService;
        private readonly InvoiceApiService _invoiceApiService;
        private readonly PdfService _pdfService;
        private readonly ILogger<CustomerPaymentsController> _logger;

        public CustomerPaymentsController(
            PaymentApiService paymentApiService,
            InvoiceApiService invoiceApiService,
            PdfService pdfService,
            ILogger<CustomerPaymentsController> logger)
        {
            _paymentApiService = paymentApiService;
            _invoiceApiService = invoiceApiService;
            _pdfService = pdfService;
            _logger = logger;
        }

        // =========================
        // LİSTE
        // =========================
        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");

            if (customerId == null)
                return RedirectToAction("Login", "Auth");

            try
            {
                var payments = await _paymentApiService.GetByCustomerIdAsync(customerId.Value);
                return View(payments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ödemeler listelenirken hata oluştu. CustomerId: {CustomerId}", customerId);
                TempData["Error"] = "Ödemeler yüklenirken bir hata oluştu.";
                return View(new List<PaymentListVM>());
            }
        }

        // =========================
        // CREATE (GET)
        // =========================
        [HttpGet("Create")]
        public async Task<IActionResult> Create(int? invoiceId)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId") ?? HttpContext.Session.GetInt32("UserId");

            if (customerId == null || customerId <= 0)
                return RedirectToAction("Login", "Auth");

            try
            {
                await LoadCustomerInvoicesToViewBag(customerId.Value);
                LoadPaymentMethodsToViewBag();

                var model = new PaymentCreateVM
                {
                    PaymentDate = DateTime.Now
                };

                if (invoiceId.HasValue)
                {
                    model.InvoiceId = invoiceId.Value;

                    var invoice = await _invoiceApiService.GetByIdAsync(invoiceId.Value);
                    if (invoice != null)
                    {
                        model.Amount = invoice.RemainingAmount;
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ödeme oluşturma sayfası yüklenirken hata oluştu. CustomerId: {CustomerId}", customerId);
                TempData["Error"] = "Sayfa yüklenirken bir hata oluştu.";
                return RedirectToAction(nameof(Index));
            }
        }

        // =========================
        // CREATE (POST)
        // =========================
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentCreateVM model)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId") ?? HttpContext.Session.GetInt32("UserId");

            if (customerId == null || customerId <= 0)
                return RedirectToAction("Login", "Auth");

            if (!ModelState.IsValid)
            {
                await LoadCustomerInvoicesToViewBag(customerId.Value);
                LoadPaymentMethodsToViewBag();
                return View(model);
            }

            try
            {
                var invoice = await _invoiceApiService.GetByIdAsync(model.InvoiceId);
                if (invoice == null)
                {
                    TempData["Error"] = "Fatura bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                var (success, message) = await _paymentApiService.CreateAsync(model);

                if (success)
                {
                    TempData["Success"] = "Ödemeniz başarıyla kaydedildi.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Error"] = message;
                    await LoadCustomerInvoicesToViewBag(customerId.Value);
                    LoadPaymentMethodsToViewBag();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ödeme kaydedilirken hata oluştu. CustomerId: {CustomerId}", customerId);
                TempData["Error"] = "Ödeme kaydedilirken bir hata oluştu.";
                await LoadCustomerInvoicesToViewBag(customerId.Value);
                LoadPaymentMethodsToViewBag();
                return View(model);
            }
        }

        // =========================
        // DETAILS
        // =========================
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var payment = await _paymentApiService.GetByIdAsync(id);
                if (payment == null)
                {
                    TempData["Error"] = "Ödeme bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                return View(payment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ödeme detayları getirilirken hata oluştu. PaymentId: {PaymentId}", id);
                TempData["Error"] = "Ödeme detayları yüklenirken bir hata oluştu.";
                return RedirectToAction(nameof(Index));
            }
        }

        // =========================
        // PDF
        // =========================
        [HttpGet("DownloadPdf/{id}")]
        public async Task<IActionResult> DownloadPdf(int id)
        {
            try
            {
                var payment = await _paymentApiService.GetByIdAsync(id);
                if (payment == null)
                {
                    TempData["Error"] = "Ödeme bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                var pdfBytes = _pdfService.GeneratePaymentReceiptPdf(payment);
                return File(pdfBytes, "application/pdf", $"OdemeMakbuzu_{payment.Id}.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ödeme PDF oluşturulurken hata. PaymentId: {PaymentId}", id);
                TempData["Error"] = "PDF oluşturulurken bir hata oluştu.";
                return RedirectToAction(nameof(Index));
            }
        }

        // =========================
        // HELPER METOTLAR (EN ÖNEMLİ KISIM)
        // =========================
        private async Task LoadCustomerInvoicesToViewBag(int customerId)
        {
            // 🔥 KRİTİK: SADECE BEKLEYEN FATURALAR
            var invoices = await _invoiceApiService.GetPendingByCustomerIdAsync(customerId);

            ViewBag.Invoices = invoices
                .Where(i => i.RemainingAmount > 0)
                .Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = $"{i.InvoiceNumber} - Kalan: {i.RemainingAmount:C2}"
                })
                .ToList();
        }

        private void LoadPaymentMethodsToViewBag()
        {
            ViewBag.PaymentMethods = new List<SelectListItem>
            {
                new SelectListItem { Value = "Cash", Text = "Nakit" },
                new SelectListItem { Value = "CreditCard", Text = "Kredi Kartı" },
                new SelectListItem { Value = "DebitCard", Text = "Banka Kartı" },
                new SelectListItem { Value = "BankTransfer", Text = "Havale/EFT" }
            };
        }
    }
}
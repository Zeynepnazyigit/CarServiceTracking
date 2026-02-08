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

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var customerId = HttpContext.Session.GetInt32("UserId")!.Value;

            try
            {
                var payments = await _paymentApiService.GetByCustomerIdAsync(customerId);
                return View(payments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ödemeler listelenirken hata oluştu. CustomerId: {CustomerId}", customerId);
                TempData["Error"] = "Ödemeler yüklenirken bir hata oluştu.";
                return View(new List<PaymentListVM>());
            }
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create(int? invoiceId)
        {
            var customerId = HttpContext.Session.GetInt32("UserId")!.Value;

            try
            {
                await LoadCustomerInvoicesToViewBag(customerId);
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

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentCreateVM model)
        {
            var customerId = HttpContext.Session.GetInt32("UserId")!.Value;

            if (!ModelState.IsValid)
            {
                await LoadCustomerInvoicesToViewBag(customerId);
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

                var result = await _paymentApiService.CreateAsync(model);

                if (result.Success)
                {
                    TempData["Success"] = "Ödemeniz başarıyla kaydedildi.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Error"] = result.Message;
                    await LoadCustomerInvoicesToViewBag(customerId);
                    LoadPaymentMethodsToViewBag();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ödeme kaydedilirken hata oluştu. CustomerId: {CustomerId}", customerId);
                TempData["Error"] = "Ödeme kaydedilirken bir hata oluştu.";
                await LoadCustomerInvoicesToViewBag(customerId);
                LoadPaymentMethodsToViewBag();
                return View(model);
            }
        }

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

        private async Task LoadCustomerInvoicesToViewBag(int customerId)
        {
            var invoices = await _invoiceApiService.GetByCustomerIdAsync(customerId);

            var pendingInvoices = invoices
                .Where(i => i.RemainingAmount > 0)
                .Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = $"{i.InvoiceNumber} - Kalan: {i.RemainingAmount:C2}"
                })
                .ToList();

            ViewBag.Invoices = pendingInvoices;
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

using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Invoices;

namespace CarServiceTracking.UI.Web.Controllers
{
    /// <summary>
    /// Müşteri fatura işlemleri controller'ı
    /// Clean Code: Single Responsibility - Sadece müşteri fatura görüntüleme işlemlerini yönetir
    /// </summary>
    [Route("Customer/Invoices")]
    public class CustomerInvoicesController : CustomerBaseController
    {
        private readonly InvoiceApiService _invoiceApiService;
        private readonly PdfService _pdfService;

        public CustomerInvoicesController(InvoiceApiService invoiceApiService, PdfService pdfService)
        {
            _invoiceApiService = invoiceApiService;
            _pdfService = pdfService;
        }

        #region Liste İşlemleri

        /// <summary>
        /// Müşterinin faturalarını listeler
        /// </summary>
        [HttpGet]
        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return RedirectToLogin();

            var invoices = await _invoiceApiService.GetByCustomerIdAsync(userId.Value);
            return View(invoices);
        }

        #endregion

        #region Detay İşlemleri

        /// <summary>
        /// Fatura detayını görüntüler
        /// </summary>
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return RedirectToLogin();

            var invoice = await _invoiceApiService.GetByIdAsync(id);
            
            if (invoice == null)
            {
                TempData["Error"] = "Fatura bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            return View(invoice);
        }

        [HttpGet]
        [Route("DownloadPdf/{id}")]
        public async Task<IActionResult> DownloadPdf(int id)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return RedirectToLogin();

            var invoice = await _invoiceApiService.GetByIdForPdfAsync(id);
            if (invoice == null)
            {
                TempData["Error"] = "Fatura bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            var pdfBytes = _pdfService.GenerateInvoicePdf(invoice);
            return File(pdfBytes, "application/pdf", $"Fatura_{invoice.InvoiceNumber}.pdf");
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Mevcut kullanıcı ID'sini session'dan alır
        /// </summary>
        private int? GetCurrentUserId()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            return (userId == null || userId <= 0) ? null : userId;
        }

        /// <summary>
        /// Login sayfasına yönlendirir
        /// </summary>
        private IActionResult RedirectToLogin()
        {
            return RedirectToAction("Login", "Auth");
        }

        #endregion
    }
}

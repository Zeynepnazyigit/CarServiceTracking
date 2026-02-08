using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.ServiceRequests;

namespace CarServiceTracking.UI.Web.Controllers
{
    [Route("Customer/ServiceRequests")]
    public class CustomerServiceRequestsController : CustomerBaseController
    {
        private readonly ServiceRequestApiService _serviceRequestApiService;
        private readonly CustomerCarApiService _customerCarApiService;
        private readonly PdfService _pdfService;

        public CustomerServiceRequestsController(
            ServiceRequestApiService serviceRequestApiService,
            CustomerCarApiService customerCarApiService,
            PdfService pdfService)
        {
            _serviceRequestApiService = serviceRequestApiService;
            _customerCarApiService = customerCarApiService;
            _pdfService = pdfService;
        }

        // SERVİS KAYITLARIM
        [HttpGet]
        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null || userId <= 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            var list = await _serviceRequestApiService.GetAllAsync();
            return View(list);
        }

        // DOWNLOAD PDF
        [HttpGet]
        [Route("DownloadPdf/{id}")]
        public async Task<IActionResult> DownloadPdf(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null || userId <= 0)
                return RedirectToAction("Login", "Auth");

            var detail = await _serviceRequestApiService.GetByIdAsync(id);
            if (detail == null)
            {
                TempData["Error"] = "Servis talebi bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            var pdfBytes = _pdfService.GenerateServiceReportPdf(detail);
            return File(pdfBytes, "application/pdf", $"ServisRaporu_{detail.Id}.pdf");
        }

        // CREATE - GET
        [HttpGet]
        [Route("Create")]
        public async Task<IActionResult> Create(int? carId = null)
        {
            var userId = HttpContext.Session.GetInt32("UserId")!.Value;
            
            // Müşterinin araçlarını getir
            var cars = await _customerCarApiService.GetByCustomerIdAsync(userId);
            ViewBag.Cars = cars;
            
            var vm = new ServiceRequestCreateVM
            {
                CarId = carId ?? 0
            };

            return View(vm);
        }

        // CREATE - POST
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceRequestCreateVM model)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null || userId <= 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            if (!ModelState.IsValid)
            {
                // Validation hatasında araç listesini tekrar yükle
                var cars = await _customerCarApiService.GetByCustomerIdAsync(userId.Value);
                ViewBag.Cars = cars;
                return View(model);
            }

            var success = await _serviceRequestApiService.CreateAsync(model, userId.Value);

            if (!success)
            {
                ModelState.AddModelError("", "Servis talebi oluşturulamadı.");
                // Hata durumunda araç listesini tekrar yükle
                var cars = await _customerCarApiService.GetByCustomerIdAsync(userId.Value);
                ViewBag.Cars = cars;
                return View(model);
            }

            TempData["Success"] = "Servis talebi başarıyla oluşturuldu!";
            return RedirectToAction(nameof(Index));
        }
    }
}

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

            var customerId = HttpContext.Session.GetInt32("CustomerId") ?? 0;
            var list = customerId > 0
                ? await _serviceRequestApiService.GetByCustomerIdAsync(customerId)
                : new List<ServiceRequestListVM>();
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

        // DETAY
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int id)
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

            return View(detail);
        }

        // CREATE - GET
        [HttpGet]
        [Route("Create")]
        public async Task<IActionResult> Create(int? carId = null)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId") ?? 0;

            // Müşterinin araçlarını getir
            var cars = await _customerCarApiService.GetByCustomerIdAsync(customerId);
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
            var customerId = HttpContext.Session.GetInt32("CustomerId") ?? 0;

            if (userId == null || userId <= 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            if (!ModelState.IsValid)
            {
                // Validation hatasında araç listesini tekrar yükle
                var cars = await _customerCarApiService.GetByCustomerIdAsync(customerId);
                ViewBag.Cars = cars;
                return View(model);
            }

            var success = await _serviceRequestApiService.CreateAsync(model, customerId);

            if (!success)
            {
                TempData["Error"] = "Servis talebi oluşturulamadı. Lütfen tekrar deneyin.";
                var cars = await _customerCarApiService.GetByCustomerIdAsync(customerId);
                ViewBag.Cars = cars;
                return View(model);
            }

            TempData["Success"] = "Servis talebi başarıyla oluşturuldu!";
            return RedirectToAction(nameof(Index));
        }

        // EDIT - GET
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId") ?? 0;

            var detail = await _serviceRequestApiService.GetByIdAsync(id);
            if (detail == null)
            {
                TempData["Error"] = "Servis talebi bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            if (detail.Status != 0)
            {
                TempData["Error"] = "Sadece beklemede olan talepler düzenlenebilir.";
                return RedirectToAction(nameof(Index));
            }

            var cars = await _customerCarApiService.GetByCustomerIdAsync(customerId);
            ViewBag.Cars = cars;

            // Car.Id -> CustomerCar.Id eslemesi (ID veya plaka uzerinden)
            var matchingCustomerCar = cars.FirstOrDefault(c => c.Id == detail.CarId)
                ?? cars.FirstOrDefault(c => detail.CarName.Contains(c.PlateNumber));
            var customerCarId = matchingCustomerCar?.Id ?? detail.CarId;

            var vm = new ServiceRequestCreateVM
            {
                CarId = customerCarId,
                ProblemDescription = detail.ProblemDescription,
                PreferredDate = detail.PreferredDate
            };

            ViewBag.ServiceRequestId = id;
            return View(vm);
        }

        // EDIT - POST
        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceRequestCreateVM model)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId") ?? 0;

            if (!ModelState.IsValid)
            {
                var cars = await _customerCarApiService.GetByCustomerIdAsync(customerId);
                ViewBag.Cars = cars;
                ViewBag.ServiceRequestId = id;
                return View(model);
            }

            var success = await _serviceRequestApiService.UpdateAsync(id, model);

            if (!success)
            {
                TempData["Error"] = "Servis talebi güncellenemedi. Lütfen tekrar deneyin.";
                var cars = await _customerCarApiService.GetByCustomerIdAsync(customerId);
                ViewBag.Cars = cars;
                ViewBag.ServiceRequestId = id;
                return View(model);
            }

            TempData["Success"] = "Servis talebi başarıyla güncellendi!";
            return RedirectToAction(nameof(Index));
        }

        // DELETE - POST
        [HttpPost]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _serviceRequestApiService.DeleteAsync(id);

            if (!success)
            {
                TempData["Error"] = "Servis talebi silinemedi.";
                return RedirectToAction(nameof(Index));
            }

            TempData["Success"] = "Servis talebi başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }
    }
}

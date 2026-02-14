using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Appointments;

namespace CarServiceTracking.UI.Web.Controllers
{
    /// <summary>
    /// Müşteri randevu işlemleri controller'ı
    /// Clean Code: Single Responsibility - Sadece müşteri randevu işlemlerini yönetir
    /// </summary>
    [Route("Customer/Appointments")]
    public class CustomerAppointmentsController : CustomerBaseController
    {
        private readonly AppointmentApiService _appointmentApiService;
        private readonly CustomerCarApiService _customerCarApiService;

        /// <summary>
        /// Constructor Injection - Dependency Inversion Principle
        /// </summary>
        public CustomerAppointmentsController(
            AppointmentApiService appointmentApiService,
            CustomerCarApiService customerCarApiService)
        {
            _appointmentApiService = appointmentApiService;
            _customerCarApiService = customerCarApiService;
        }

        #region Liste İşlemleri

        /// <summary>
        /// Müşterinin randevularını listeler
        /// </summary>
        [HttpGet]
        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var customerId = GetCurrentCustomerId();
            if (customerId == null)
                return RedirectToLogin();

            var appointments = await _appointmentApiService.GetByCustomerIdAsync(customerId.Value);
            return View(appointments);
        }

        /// <summary>
        /// Randevu detay sayfası
        /// </summary>
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return RedirectToLogin();

            var detail = await _appointmentApiService.GetByIdAsync(id);
            if (detail == null)
            {
                TempData["Error"] = "Randevu bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            return View(detail);
        }

        #endregion

        #region Oluşturma İşlemleri

        /// <summary>
        /// Yeni randevu oluşturma formu
        /// </summary>
        [HttpGet]
        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            var customerId = GetCurrentCustomerId();
            if (customerId == null)
                return RedirectToLogin();

            // Müşterinin araçlarını dropdown için getir (CustomerId ile - araçlar müşteriye bağlı)
            await LoadCustomerCarsToViewBag(customerId.Value);

            var model = new AppointmentCreateVM
            {
                CustomerId = customerId.Value,
                AppointmentDate = DateTime.Today.AddDays(1) // Yarın varsayılan
            };

            return View(model);
        }

        /// <summary>
        /// Yeni randevu oluşturma POST
        /// </summary>
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentCreateVM model)
        {
            var customerId = GetCurrentCustomerId();
            if (customerId == null)
                return RedirectToLogin();

            // CustomerId'yi session'dan al (güvenlik için - araçlar müşteriye bağlı)
            model.CustomerId = customerId.Value;

            if (!ModelState.IsValid)
            {
                await LoadCustomerCarsToViewBag(customerId.Value);
                return View(model);
            }

            var (success, message) = await _appointmentApiService.CreateAsync(model);

            if (!success)
            {
                ModelState.AddModelError(string.Empty, message);
                await LoadCustomerCarsToViewBag(customerId.Value);
                return View(model);
            }

            TempData["Success"] = "Randevu başarıyla oluşturuldu!";
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region İptal İşlemleri

        /// <summary>
        /// Randevu iptal etme
        /// </summary>
        [HttpPost]
        [Route("Cancel/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id, string? reason)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return RedirectToLogin();

            var cancellationReason = string.IsNullOrWhiteSpace(reason) 
                ? "Müşteri talebi ile iptal edildi" 
                : reason;

            var (success, message) = await _appointmentApiService.CancelAsync(id, cancellationReason);

            if (success)
                TempData["Success"] = "Randevu başarıyla iptal edildi.";
            else
                TempData["Error"] = message;

            return RedirectToAction(nameof(Index));
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
        /// Mevcut müşteri ID'sini session'dan alır (araçlar müşteriye bağlı).
        /// CustomerId yoksa UserId fallback (bazı kurulumlarda aynı olabilir).
        /// </summary>
        private int? GetCurrentCustomerId()
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId != null && customerId > 0)
                return customerId;
            return HttpContext.Session.GetInt32("UserId");
        }

        /// <summary>
        /// Login sayfasına yönlendirir
        /// </summary>
        private IActionResult RedirectToLogin()
        {
            return RedirectToAction("Login", "Auth");
        }

        /// <summary>
        /// Müşterinin araçlarını ViewBag'e yükler
        /// </summary>
        private async Task LoadCustomerCarsToViewBag(int customerId)
        {
            var cars = await _customerCarApiService.GetByCustomerIdAsync(customerId);
            ViewBag.Cars = cars ?? new List<ViewModels.CustomerCars.CustomerCarVM>();
        }

        #endregion
    }
}

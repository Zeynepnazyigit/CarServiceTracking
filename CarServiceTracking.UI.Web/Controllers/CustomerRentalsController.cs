using Microsoft.AspNetCore.Mvc;
using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.ViewModels.Rentals;

namespace CarServiceTracking.UI.Web.Controllers
{
    [Route("Customer/Rentals")]
    public class CustomerRentalsController : CustomerBaseController
    {
        private readonly RentalApiService _rentalApiService;
        private readonly InvoiceApiService _invoiceApiService;

        public CustomerRentalsController(
            RentalApiService rentalApiService,
            InvoiceApiService invoiceApiService)
        {
            _rentalApiService = rentalApiService;
            _invoiceApiService = invoiceApiService;
        }

        // KİRALAMA LİSTESİ
        [HttpGet]
        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null || customerId.Value <= 0)
            {
                TempData["Error"] = "Oturum süreniz dolmuş. Lütfen tekrar giriş yapın.";
                return RedirectToAction("Login", "Auth");
            }

            var rentals = await _rentalApiService.GetCustomerRentalsAsync(customerId.Value);

            // Kiralama listesine odeme durumu bilgisi ekle
            if (rentals != null && rentals.Any())
            {
                try
                {
                    var invoices = await _invoiceApiService.GetByCustomerIdAsync(customerId.Value);
                    foreach (var rental in rentals)
                    {
                        var matchingInvoice = invoices?.FirstOrDefault(i =>
                            i.RentalAgreementId.HasValue && i.RentalAgreementId == rental.Id);

                        if (matchingInvoice != null)
                        {
                            rental.InvoiceId = matchingInvoice.Id;
                            rental.PaymentStatusText = matchingInvoice.PaymentStatus switch
                            {
                                "Paid" => "Ödendi",
                                "Partial" => "Kısmi Ödendi",
                                _ => "Bekliyor"
                            };
                        }
                    }
                }
                catch { /* Fatura bilgisi alinamazsa listeyi yine de goster */ }
            }

            return View(rentals ?? new List<CustomerRentalListVM>());
        }

        // KİRALAMA OLUŞTURMA SAYFASI
        [HttpGet]
        [Route("Create")]
        public async Task<IActionResult> Create(int carId)
        {
            if (carId <= 0)
                return RedirectToAction("Index", "CustomerCarsList");

            var vehicleDetail = await _rentalApiService.GetVehicleDetailAsync(carId);
            if (vehicleDetail == null)
            {
                TempData["Error"] = "Araç bulunamadı.";
                return RedirectToAction("Index", "CustomerCarsList");
            }

            var model = new RentalCreateVM
            {
                VehicleId = carId,
                VehicleName = $"{vehicleDetail.Brand} {vehicleDetail.Model}",
                DailyRate = vehicleDetail.DailyRate,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1)
            };

            return View(model);
        }

        // KİRALAMA OLUŞTUR - POST
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RentalCreateVM model)
        {
            // 1) Session kontrol (null gelirse patlamasın)
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null || customerId.Value <= 0)
            {
                TempData["Error"] = "Oturum süreniz dolmuş. Lütfen tekrar giriş yapın.";
                return RedirectToAction("Login", "Auth");
            }

            // 2) CustomerId'yi server set et (hidden'a güvenme)
            model.CustomerId = customerId.Value;

            // 3) Basit iş kuralı: tarih mantığı
            if (model.EndDate <= model.StartDate)
                ModelState.AddModelError(nameof(model.EndDate), "İade tarihi, teslim tarihinden sonra olmalıdır.");

            // 4) Model hatası varsa: aynı sayfaya DÖNME, GET ile tekrar doldur
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Lütfen form alanlarını kontrol edin.";
                return RedirectToAction(nameof(Create), new { carId = model.VehicleId });
            }

            // 5) API'ye kiralama isteği
            var result = await _rentalApiService.CreateRentalAsync(model);

            // 6) Başarısızsa: hata mesajını TempData ile bas, GET'e dön
            if (!result.Success)
            {
                TempData["Error"] = result.Message;
                return RedirectToAction(nameof(Create), new { carId = model.VehicleId });
            }

            // 7) Başarılıysa: direkt "Kiralamalarım" sayfasına dön
            TempData["Success"] = "Kiralama işlemi başarıyla oluşturuldu!";
            return RedirectToAction(nameof(Index));
        }

        // KİRALAMA DETAY
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var rental = await _rentalApiService.GetRentalDetailAsync(id);
            if (rental == null)
            {
                TempData["Error"] = "Kiralama bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            // Fatura bilgisi ekle
            try
            {
                var invoices = await _invoiceApiService.GetByCustomerIdAsync(rental.CustomerId);
                var matchingInvoice = invoices?.FirstOrDefault(i =>
                    i.RentalAgreementId.HasValue && i.RentalAgreementId == rental.Id);

                if (matchingInvoice != null)
                {
                    rental.InvoiceId = matchingInvoice.Id;
                    rental.PaidAmount = matchingInvoice.PaidAmount;
                    rental.RemainingAmount = matchingInvoice.RemainingAmount;
                    rental.GrandTotal = matchingInvoice.TotalAmount;
                    rental.PaymentStatusText = matchingInvoice.PaymentStatus switch
                    {
                        "Paid" => "Ödendi",
                        "Partial" => "Kısmi Ödendi",
                        _ => "Bekliyor"
                    };
                }
            }
            catch { /* Fatura bilgisi alinamazsa detayi yine de goster */ }

            return View(rental);
        }

        // KİRALAMA BAŞARILI
        [HttpGet]
        [Route("Success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}

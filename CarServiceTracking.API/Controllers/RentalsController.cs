using CarServiceTracking.API.Authorization;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.DTOs.RentalDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        private readonly IInvoiceService _invoiceService;

        public RentalsController(IRentalService rentalService, IInvoiceService invoiceService)
        {
            _rentalService = rentalService;
            _invoiceService = invoiceService;
        }

        #region RentalVehicle Endpoints

        // GET: api/rentals/vehicles
        [HttpGet("vehicles")]
        public async Task<IActionResult> GetAllVehicles()
        {
            var result = await _rentalService.GetAllVehiclesAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/rentals/vehicles/available
        // Not: Müşteri UI'sinde login/token problemi yaşandığında hata almamak için
        // bu endpoint'i şimdilik anonim okuma için açıyoruz.
        [HttpGet("vehicles/available")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAvailableVehicles()
        {
            var result = await _rentalService.GetAvailableVehiclesAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/rentals/vehicles/{id}
        [HttpGet("vehicles/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            var result = await _rentalService.GetVehicleByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/rentals/vehicles
        [HttpPost("vehicles")]
        public async Task<IActionResult> CreateVehicle([FromBody] RentalVehicleCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _rentalService.CreateVehicleAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetVehicleById), new { id = result.Data?.Id }, result);
        }

        // PUT: api/rentals/vehicles/{id}
        [HttpPut("vehicles/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] RentalVehicleUpdateDTO dto)
        {
            if (dto == null)
                return BadRequest(new { success = false, message = "Geçersiz istek gövdesi." });

            if (id != dto.Id)
                return BadRequest(new { success = false, message = "ID uyuşmazlığı." });

            if (!ModelState.IsValid)
            {
                var firstError = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault()?.ErrorMessage;
                return BadRequest(new { success = false, message = firstError ?? "Validasyon hatası." });
            }

            var result = await _rentalService.UpdateVehicleAsync(dto);

            if (!result.Success)
                return BadRequest(new { success = false, message = result.Message });

            return Ok(result);
        }

        // DELETE: api/rentals/vehicles/{id}
        [HttpDelete("vehicles/{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var result = await _rentalService.DeleteVehicleAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // POST: api/rentals/vehicles/set-all-available
        [HttpPost("vehicles/set-all-available")]
        [AllowAnonymous]
        public async Task<IActionResult> SetAllVehiclesAvailable()
        {
            var result = await _rentalService.SetAllVehiclesAvailableAsync();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // POST: api/rentals/vehicles/sync-availability
        [HttpPost("vehicles/sync-availability")]
        [AllowAnonymous]
        public async Task<IActionResult> SyncVehicleAvailability()
        {
            var result = await _rentalService.SyncVehicleAvailabilityAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion

        #region RentalAgreement Endpoints

        // GET: api/rentals/agreements
        [HttpGet("agreements")]
        public async Task<IActionResult> GetAllAgreements()
        {
            var result = await _rentalService.GetAllAgreementsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/rentals/agreements/active
        [HttpGet("agreements/active")]
        public async Task<IActionResult> GetActiveAgreements()
        {
            var result = await _rentalService.GetActiveAgreementsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/rentals/agreements/customer/{customerId}
        // Not: Müşteri UI'sinde "Kiralamalarım" sayfası için kullanılıyor.
        // UI zaten session'dan CustomerId'yi alıyor, bu yüzden burada ekstra auth yerine
        // anonim okuma yeterli. Yazma işlemleri yine auth gerektiriyor.
        [HttpGet("agreements/customer/{customerId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAgreementsByCustomer(int customerId)
        {
            var result = await _rentalService.GetByCustomerIdAsync(customerId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/rentals/agreements/overdue
        [HttpGet("agreements/overdue")]
        public async Task<IActionResult> GetOverdueAgreements()
        {
            var result = await _rentalService.GetOverdueAgreementsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/rentals/agreements/{id}
        [HttpGet("agreements/{id}")]
        [UserOnly]
        public async Task<IActionResult> GetAgreementById(int id)
        {
            var result = await _rentalService.GetAgreementByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/rentals/agreements
        [HttpPost("agreements")]
        [UserOnly]
        public async Task<IActionResult> CreateAgreement([FromBody] RentalAgreementCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _rentalService.CreateAgreementAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetAgreementById), new { id = result.Data?.Id }, result);
        }


        [HttpPost("rent")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRental(
            [FromBody] RentalAgreementCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _rentalService.CreateRentalWithVehicleLockAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            // Kiralama basarili ise otomatik fatura olustur
            if (result.Data != null)
            {
                try
                {
                    await _invoiceService.CreateRentalInvoiceAsync(result.Data.Id);
                }
                catch
                {
                    // Fatura olusturma hatasi kiralama basarisini etkilemesin
                    // Fatura daha sonra manuel olusturulabilir
                }
            }

            return Ok(result);
        }

        // PUT: api/rentals/agreements/{id}
        [HttpPut("agreements/{id}")]
        public async Task<IActionResult> UpdateAgreement(int id, [FromBody] RentalAgreementUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _rentalService.UpdateAgreementAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/rentals/agreements/{id}
        [HttpDelete("agreements/{id}")]
        public async Task<IActionResult> DeleteAgreement(int id)
        {
            var result = await _rentalService.DeleteAgreementAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // POST: api/rentals/agreements/{id}/complete
        [HttpPost("agreements/{id}/complete")]
        [AllowAnonymous]   // ← BUNU EKLE
        public async Task<IActionResult> CompleteRental(int id, [FromBody] CompleteRentalRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _rentalService.CompleteRentalAsync(id, request.EndMileage, request.ReturnDate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion
    }

    public class CompleteRentalRequest
    {
        public int EndMileage { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}

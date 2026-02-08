using CarServiceTracking.API.Authorization;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.DTOs.PaymentDTOs;
using CarServiceTracking.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: api/payments
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _paymentService.GetAllAsync();
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/payments/invoice/{invoiceId}
        [HttpGet("invoice/{invoiceId}")]
        [UserOnly]
        public async Task<IActionResult> GetByInvoice(int invoiceId)
        {
            var result = await _paymentService.GetByInvoiceIdAsync(invoiceId);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/payments/method/{method}
        [HttpGet("method/{method}")]
        public async Task<IActionResult> GetByMethod(PaymentMethod method)
        {
            var result = await _paymentService.GetByPaymentMethodAsync(method);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/payments/date-range
        [HttpGet("date-range")]
        public async Task<IActionResult> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var result = await _paymentService.GetByDateRangeAsync(startDate, endDate);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/payments/{id}
        [HttpGet("{id}")]
        [UserOnly]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _paymentService.GetByIdAsync(id);
            
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/payments
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaymentCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _paymentService.CreateAsync(dto);
            
            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data?.Id }, result);
        }

        // PUT: api/payments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PaymentUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _paymentService.UpdateAsync(dto);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/payments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _paymentService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/payments/customer/{customerId}
        /// <summary>
        /// Müşteriye ait tüm ödemeleri getirir.
        /// </summary>
        [HttpGet("customer/{customerId}")]
        [UserOnly]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            var result = await _paymentService.GetByCustomerIdAsync(customerId);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

using CarServiceTracking.API.Authorization;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.DTOs.InvoiceDTOs;
using CarServiceTracking.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: api/invoices
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _invoiceService.GetAllAsync();
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/invoices/customer/{customerId}
        /// <summary>
        /// Müşteriye ait faturaları getirir
        /// </summary>
        [HttpGet("customer/{customerId}")]
        [UserOnly]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            var result = await _invoiceService.GetByCustomerIdAsync(customerId);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/invoices/service-request/{serviceRequestId}
        [HttpGet("service-request/{serviceRequestId}")]
        [UserOnly]
        public async Task<IActionResult> GetByServiceRequest(int serviceRequestId)
        {
            var result = await _invoiceService.GetByServiceRequestIdAsync(serviceRequestId);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/invoices/status/{status}
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(PaymentStatus status)
        {
            var result = await _invoiceService.GetByPaymentStatusAsync(status);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/invoices/overdue
        [HttpGet("overdue")]
        public async Task<IActionResult> GetOverdue()
        {
            var result = await _invoiceService.GetOverdueInvoicesAsync();
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/invoices/{id}
        [HttpGet("{id}")]
        [UserOnly]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _invoiceService.GetByIdAsync(id);
            
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // GET: api/invoices/number/{invoiceNumber}
        [HttpGet("number/{invoiceNumber}")]
        public async Task<IActionResult> GetByInvoiceNumber(string invoiceNumber)
        {
            var result = await _invoiceService.GetByInvoiceNumberAsync(invoiceNumber);
            
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/invoices
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoiceCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _invoiceService.CreateAsync(dto);
            
            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data?.Id }, result);
        }

        // POST: api/invoices/from-service-request/{serviceRequestId}
        /// <param name="replace">true ise bu servis talebi için mevcut fatura soft-delete edilip yenisi oluşturulur.</param>
        [HttpPost("from-service-request/{serviceRequestId}")]
        public async Task<IActionResult> CreateFromServiceRequest(int serviceRequestId, [FromQuery] bool replace = false)
        {
            var result = await _invoiceService.CreateFromServiceRequestAsync(serviceRequestId, replace);
            
            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data?.Id }, result);
        }

        // POST: api/invoices/from-rental/{rentalAgreementId}
        [HttpPost("from-rental/{rentalAgreementId}")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateFromRentalAgreement(int rentalAgreementId)
        {
            var result = await _invoiceService.CreateRentalInvoiceAsync(rentalAgreementId);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data?.Id }, result);
        }

        // GET: api/invoices/customer/{customerId}/pending
        [HttpGet("customer/{customerId}/pending")]
        [UserOnly]
        public async Task<IActionResult> GetPendingByCustomer(int customerId)
        {
            var result = await _invoiceService.GetPendingInvoicesByCustomerIdAsync(customerId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // PUT: api/invoices/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InvoiceUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _invoiceService.UpdateAsync(dto);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/invoices/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _invoiceService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

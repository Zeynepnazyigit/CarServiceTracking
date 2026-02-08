using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.DTOs.ServiceRequestDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly IServiceRequestService _serviceRequestService;

        public ServiceRequestsController(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        // ✅ POST: api/ServiceRequests
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServiceRequestCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 🔥 DEMO – şimdilik sabit müşteri
            dto.CustomerId = 1;

            var result = await _serviceRequestService.CreateAsync(dto);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }


        // ✅ GET: api/ServiceRequests
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _serviceRequestService.GetAllAsync();

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        // ✅ PUT: api/ServiceRequests/{id}/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateStatusRequest request)
        {
            var result = await _serviceRequestService.UpdateStatusAsync(id, request.Status, request.ServicePrice, request.AdminNote);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // ✅ DELETE: api/ServiceRequests/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _serviceRequestService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // ✅ GET: api/ServiceRequests/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _serviceRequestService.GetByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            var list = await _serviceRequestService.GetByCustomerIdAsync(customerId);
            return Ok(list);
        }
    }

    // Helper class for UpdateStatus
    public class UpdateStatusRequest
    {
        public int Status { get; set; }
        public decimal? ServicePrice { get; set; }
        public string? AdminNote { get; set; }
    }
}

using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.DTOs.ServiceAssignmentDTOs;
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
        private readonly IServiceAssignmentService _serviceAssignmentService;

        public ServiceRequestsController(
            IServiceRequestService serviceRequestService,
            IServiceAssignmentService serviceAssignmentService)
        {
            _serviceRequestService = serviceRequestService;
            _serviceAssignmentService = serviceAssignmentService;
        }

        // POST: api/ServiceRequests
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServiceRequestCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // CustomerId body'den geliyorsa kullan, gelmemişse JWT'den al
            if (dto.CustomerId <= 0)
            {
                var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (int.TryParse(userIdClaim, out var userId))
                    dto.CustomerId = userId;
            }

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

        // PUT: api/ServiceRequests/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ServiceRequestUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _serviceRequestService.UpdateAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

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

        // ======================================================
        // Teknisyen Atama (ServiceAssignment) Endpoints
        // ======================================================

        // GET: api/ServiceRequests/{id}/assignments
        [HttpGet("{id}/assignments")]
        public async Task<IActionResult> GetAssignments(int id)
        {
            var result = await _serviceAssignmentService.GetByServiceRequestIdAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // POST: api/ServiceRequests/{id}/assignments
        [HttpPost("{id}/assignments")]
        public async Task<IActionResult> AssignMechanic(int id, [FromBody] ServiceAssignmentCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dto.ServiceRequestId = id;

            var result = await _serviceAssignmentService.AssignAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/ServiceRequests/{serviceRequestId}/assignments/{assignmentId}
        [HttpDelete("{serviceRequestId}/assignments/{assignmentId}")]
        public async Task<IActionResult> RemoveAssignment(int serviceRequestId, int assignmentId)
        {
            var result = await _serviceAssignmentService.RemoveAsync(assignmentId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
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

using CarServiceTracking.API.Authorization;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.DTOs.AppointmentDTOs;
using CarServiceTracking.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: api/appointments
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _appointmentService.GetAllAsync();
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/appointments/customer/{customerId}
        [HttpGet("customer/{customerId}")]
        [UserOnly]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            var result = await _appointmentService.GetByCustomerIdAsync(customerId);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/appointments/date/{date}
        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetByDate(DateTime date)
        {
            var result = await _appointmentService.GetByDateAsync(date);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/appointments/status/{status}
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(AppointmentStatus status)
        {
            var result = await _appointmentService.GetByStatusAsync(status);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/appointments/{id}
        [HttpGet("{id}")]
        [UserOnly]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _appointmentService.GetByIdAsync(id);
            
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/appointments
        [HttpPost]
        [UserOnly]
        public async Task<IActionResult> Create([FromBody] AppointmentCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _appointmentService.CreateAsync(dto);
            
            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data?.Id }, result);
        }

        // PUT: api/appointments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AppointmentUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _appointmentService.UpdateAsync(dto);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/appointments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _appointmentService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // POST: api/appointments/{id}/confirm
        [HttpPost("{id}/confirm")]
        public async Task<IActionResult> Confirm(int id)
        {
            var result = await _appointmentService.ConfirmAppointmentAsync(id);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // POST: api/appointments/{id}/cancel
        [HttpPost("{id}/cancel")]
        [UserOnly]
        public async Task<IActionResult> Cancel(int id, [FromBody] string reason)
        {
            var result = await _appointmentService.CancelAppointmentAsync(id, reason);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

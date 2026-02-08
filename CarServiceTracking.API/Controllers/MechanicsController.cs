using CarServiceTracking.API.Authorization;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.DTOs.MechanicDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MechanicsController : ControllerBase
    {
        private readonly IMechanicService _mechanicService;

        public MechanicsController(IMechanicService mechanicService)
        {
            _mechanicService = mechanicService;
        }

        // GET: api/mechanics
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mechanicService.GetAllAsync();
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/mechanics/available
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailable()
        {
            var result = await _mechanicService.GetAvailableMechanicsAsync();
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/mechanics/specialization/{specialization}
        [HttpGet("specialization/{specialization}")]
        public async Task<IActionResult> GetBySpecialization(string specialization)
        {
            var result = await _mechanicService.GetBySpecializationAsync(specialization);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/mechanics/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mechanicService.GetByIdAsync(id);
            
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/mechanics
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MechanicCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mechanicService.CreateAsync(dto);
            
            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data?.Id }, result);
        }

        // PUT: api/mechanics/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MechanicUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mechanicService.UpdateAsync(dto);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/mechanics/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mechanicService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

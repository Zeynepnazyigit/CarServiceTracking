using CarServiceTracking.API.Authorization;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.DTOs.PartDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PartsController : ControllerBase
    {
        private readonly IPartService _partService;

        public PartsController(IPartService partService)
        {
            _partService = partService;
        }

        // GET: api/parts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _partService.GetAllAsync();
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/parts/low-stock
        [HttpGet("low-stock")]
        public async Task<IActionResult> GetLowStock()
        {
            var result = await _partService.GetLowStockPartsAsync();
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/parts/category/{category}
        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            var result = await _partService.GetByCategoryAsync(category);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/parts/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _partService.GetByIdAsync(id);
            
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // GET: api/parts/code/{partCode}
        [HttpGet("code/{partCode}")]
        public async Task<IActionResult> GetByPartCode(string partCode)
        {
            var result = await _partService.GetByPartCodeAsync(partCode);
            
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/parts
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PartCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _partService.CreateAsync(dto);
            
            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data?.Id }, result);
        }

        // PUT: api/parts/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PartUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _partService.UpdateAsync(dto);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/parts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _partService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // PATCH: api/parts/{id}/stock
        [HttpPatch("{id}/stock")]
        public async Task<IActionResult> UpdateStock(int id, [FromBody] int quantity)
        {
            var result = await _partService.UpdateStockAsync(id, quantity);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

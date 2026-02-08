using CarServiceTracking.API.Authorization;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.DTOs.ListItemDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ListItemsController : ControllerBase
    {
        private readonly IListItemService _listItemService;

        public ListItemsController(IListItemService listItemService)
        {
            _listItemService = listItemService;
        }

        // GET: api/listitems
        [HttpGet]
        [AdminOnly]
        public async Task<IActionResult> GetAll()
        {
            var result = await _listItemService.GetAllAsync();
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/listitems/type/{listType}
        [HttpGet("type/{listType}")]
        public async Task<IActionResult> GetByType(string listType)
        {
            var result = await _listItemService.GetByTypeAsync(listType);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/listitems/{id}
        [HttpGet("{id}")]
        [AdminOnly]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _listItemService.GetByIdAsync(id);
            
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/listitems
        [HttpPost]
        [AdminOnly]
        public async Task<IActionResult> Create([FromBody] ListItemCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _listItemService.CreateAsync(dto);
            
            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data?.Id }, result);
        }

        // PUT: api/listitems/{id}
        [HttpPut("{id}")]
        [AdminOnly]
        public async Task<IActionResult> Update(int id, [FromBody] ListItemUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _listItemService.UpdateAsync(dto);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/listitems/{id}
        [HttpDelete("{id}")]
        [AdminOnly]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _listItemService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.DTOs.CustomerDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarServiceTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetAllAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveCustomers()
        {
            var result = await _customerService.GetActiveCustomersAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("list-items")]
        public async Task<IActionResult> GetCustomerListItems()
        {
            var result = await _customerService.GetCustomerListItemsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _customerService.GetByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _customerService.CreateAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest(new { success = false, message = "ID uyuşmazlığı." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _customerService.UpdateAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customerService.SoftDeleteAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch("{id}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var result = await _customerService.SetActiveAsync(id, true);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch("{id}/deactivate")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var result = await _customerService.SetActiveAsync(id, false);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
    


using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.DTOs.CarDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarServiceTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/cars
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? search)
        {
            var result = string.IsNullOrWhiteSpace(search)
                ? await _carService.GetAllAsync()
                : await _carService.SearchCarsAsync(search);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/cars/active
        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var result = await _carService.GetActiveAsync();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/cars/list-items
        [HttpGet("list-items")]
        public async Task<IActionResult> GetCarListItems()
        {
            var result = await _carService.GetCarListItemsAsync();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/cars/by-customer/5
        [HttpGet("by-customer/{customerId}")]
        public async Task<IActionResult> GetCarsByCustomerId(int customerId)
        {
            var result = await _carService.GetCarsByCustomerIdAsync(customerId);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/cars/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _carService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/cars/by-plate/34ABC123
        [HttpGet("by-plate/{plateNumber}")]
        public async Task<IActionResult> GetByPlateNumber(string plateNumber)
        {
            var result = await _carService.GetByPlateNumberAsync(plateNumber);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // POST: api/cars
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarCreateDTO dto)
        {
            var result = await _carService.CreateAsync(dto);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // PUT: api/cars
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CarUpdateDTO dto)
        {
            var result = await _carService.UpdateAsync(dto);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await _carService.SoftDeleteAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // PATCH: api/cars/5/activate
        [HttpPatch("{id}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var result = await _carService.SetActiveAsync(id, true);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // PATCH: api/cars/5/deactivate
        [HttpPatch("{id}/deactivate")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var result = await _carService.SetActiveAsync(id, false);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

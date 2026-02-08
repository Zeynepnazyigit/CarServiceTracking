using CarServiceTracking.Core.DTOs.CustomerCarDTOs;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CustomerCarsController : ControllerBase
    {
        private readonly ICustomerCarService _customerCarService;

        public CustomerCarsController(ICustomerCarService customerCarService)
        {
            _customerCarService = customerCarService;
        }

        // ======================================================
        // GET: api/CustomerCars?customerId=1
        // ======================================================
        [HttpGet]
        public async Task<IActionResult> GetByCustomerId([FromQuery] int customerId)
        {
            if (customerId <= 0)
                return BadRequest("customerId zorunludur.");

            var cars = await _customerCarService.GetByCustomerIdAsync(customerId);

            var dtoList = cars.Select(x => new CustomerCarListDTO
            {
                Id = x.Id,
                BrandModel = x.BrandModel,
                PlateNumber = x.PlateNumber,
                Year = x.Year,
                Mileage = x.Mileage,
                Color = x.Color,
                IsInService = x.IsInService
            }).ToList();

            return Ok(dtoList);
            ;
        }

        // ======================================================
        // GET: api/CustomerCars/5
        // ======================================================
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("id zorunludur.");

            var car = await _customerCarService.GetByIdAsync(id);
            if (car == null)
                return NotFound();

            var dto = new CustomerCarListDTO
            {
                Id = car.Id,
                BrandModel = car.BrandModel,
                PlateNumber = car.PlateNumber,
                Year = car.Year,
                Mileage = car.Mileage,
                Color = car.Color,
                IsInService = car.IsInService
            };

            return Ok(dto);

        }

        // ======================================================
        // POST: api/CustomerCars
        // ======================================================
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerCarCreateDTO dto)
        {
            if (dto == null)
                return BadRequest("Body boş olamaz.");

            if (dto.CustomerId <= 0)
                return BadRequest("CustomerId zorunludur.");

            if (string.IsNullOrWhiteSpace(dto.BrandModel))
                return BadRequest("BrandModel zorunludur.");

            if (string.IsNullOrWhiteSpace(dto.PlateNumber))
                return BadRequest("PlateNumber zorunludur.");

            var customerCar = new CustomerCar
            {
                CustomerId = dto.CustomerId,
                BrandModel = dto.BrandModel,
                PlateNumber = dto.PlateNumber,
                Year = dto.Year,
                Mileage = dto.Mileage ?? 0,
                Color = dto.Color,
                IsInService = dto.IsInService,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };

            var created = await _customerCarService.AddAsync(customerCar);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new { created.Id }
            );
        }
    }
}

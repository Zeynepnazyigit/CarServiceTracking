using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.DTOs;
using CarServiceTracking.Core.DTOs.CustomerDTOs;
using CarServiceTracking.API.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace CarServiceTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]  // Tüm endpoint'ler authentication gerektiriyor
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Tüm müşterileri listele - ADMIN ONLY
        /// </summary>
        [HttpGet]
        [AdminOnly]
        public async Task<ActionResult<ApiResponse<List<CustomerListDTO>>>> GetAll()
        {
            var result = await _customerService.GetAllAsync();

            if (!result.Success)
                return BadRequest(ApiResponse<List<CustomerListDTO>>.ErrorResponse(result.Message));

            return Ok(ApiResponse<List<CustomerListDTO>>.SuccessResponse(result.Data, result.Message));
        }

        /// <summary>
        /// Aktif müşterileri listele - ADMIN ONLY
        /// </summary>
        [HttpGet("active")]
        [AdminOnly]
        public async Task<ActionResult<ApiResponse<List<CustomerListDTO>>>> GetActiveCustomers()
        {
            var result = await _customerService.GetActiveCustomersAsync();

            if (!result.Success)
                return BadRequest(ApiResponse<List<CustomerListDTO>>.ErrorResponse(result.Message));

            return Ok(ApiResponse<List<CustomerListDTO>>.SuccessResponse(result.Data, result.Message));
        }

        /// <summary>
        /// Müşteri dropdown listesi - USER ONLY
        /// </summary>
        [HttpGet("list-items")]
        [UserOnly]
        public async Task<ActionResult<ApiResponse<List<CustomerListItemDTO>>>> GetCustomerListItems()
        {
            var result = await _customerService.GetCustomerListItemsAsync();

            if (!result.Success)
                return BadRequest(ApiResponse<List<CustomerListItemDTO>>.ErrorResponse(result.Message));

            return Ok(ApiResponse<List<CustomerListItemDTO>>.SuccessResponse(result.Data, result.Message));
        }

        /// <summary>
        /// Müşteri detayı - ADMIN ONLY
        /// </summary>
        [HttpGet("{id}")]
        [AdminOnly]
        public async Task<ActionResult<ApiResponse<CustomerDetailDTO>>> GetById(int id)
        {
            var result = await _customerService.GetByIdAsync(id);

            if (!result.Success)
                return NotFound(ApiResponse<CustomerDetailDTO>.ErrorResponse(result.Message));

            return Ok(ApiResponse<CustomerDetailDTO>.SuccessResponse(result.Data, result.Message));
        }

        /// <summary>
        /// Müşteri oluştur - ADMIN ONLY
        /// </summary>
        [HttpPost]
        [AdminOnly]
        public async Task<ActionResult<ApiResponse<CustomerDetailDTO>>> Create([FromBody] CustomerCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse<CustomerDetailDTO>.ErrorResponse("Validasyon hatası", ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList()));

            var result = await _customerService.CreateAsync(dto);

            if (!result.Success)
                return BadRequest(ApiResponse<CustomerDetailDTO>.ErrorResponse(result.Message));

            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, 
                ApiResponse<CustomerDetailDTO>.SuccessResponse(result.Data, "Müşteri başarıyla oluşturuldu"));
        }

        /// <summary>
        /// Müşteri güncelle - ADMIN ONLY
        /// </summary>
        [HttpPut("{id}")]
        [AdminOnly]
        public async Task<ActionResult<ApiResponse<CustomerDetailDTO>>> Update(int id, [FromBody] CustomerUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest(new { success = false, message = "ID uyuşmazlığı." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _customerService.UpdateAsync(dto);

            if (!result.Success)
                return BadRequest(ApiResponse<CustomerDetailDTO>.ErrorResponse(result.Message));

            return Ok(ApiResponse<CustomerDetailDTO>.SuccessResponse(result.Data, result.Message));
        }

        /// <summary>
        /// Müşteri sil (soft delete) - ADMIN ONLY
        /// </summary>
        [HttpDelete("{id}")]
        [AdminOnly]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            var result = await _customerService.SoftDeleteAsync(id);

            if (!result.Success)
                return BadRequest(ApiResponse.ErrorResponse(result.Message));

            return Ok(ApiResponse.SuccessResponse(result.Message));
        }

        /// <summary>
        /// Müşteri aktif et - ADMIN ONLY
        /// </summary>
        [HttpPatch("{id}/activate")]
        [AdminOnly]
        public async Task<ActionResult<ApiResponse>> Activate(int id)
        {
            var result = await _customerService.SetActiveAsync(id, true);

            if (!result.Success)
                return BadRequest(ApiResponse.ErrorResponse(result.Message));

            return Ok(ApiResponse.SuccessResponse(result.Message));
        }

        /// <summary>
        /// Müşteri pasif et - ADMIN ONLY
        /// </summary>
        [HttpPatch("{id}/deactivate")]
        [AdminOnly]
        public async Task<ActionResult<ApiResponse>> Deactivate(int id)
        {
            var result = await _customerService.SetActiveAsync(id, false);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
    


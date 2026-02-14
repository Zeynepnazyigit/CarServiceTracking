using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.DTOs;
using CarServiceTracking.Core.DTOs.SettingsDTOs;
using CarServiceTracking.API.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SettingsController : ControllerBase
    {
        private readonly ICompanySettingsService _settingsService;

        public SettingsController(ICompanySettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        /// <summary>
        /// Sistem ayarlarını getir - ADMIN ONLY
        /// </summary>
        [HttpGet]
        [AdminOnly]
        public async Task<ActionResult<ApiResponse<CompanySettingsDTO>>> Get()
        {
            var result = await _settingsService.GetAsync();

            if (!result.Success)
                return NotFound(ApiResponse<CompanySettingsDTO>.ErrorResponse(result.Message));

            return Ok(ApiResponse<CompanySettingsDTO>.SuccessResponse(result.Data!, result.Message));
        }

        /// <summary>
        /// Sistem ayarlarını güncelle - ADMIN ONLY
        /// </summary>
        [HttpPut]
        [AdminOnly]
        public async Task<ActionResult<ApiResponse>> Update([FromBody] CompanySettingsDTO dto)
        {
            var result = await _settingsService.UpdateAsync(dto);

            if (!result.Success)
                return BadRequest(ApiResponse.ErrorResponse(result.Message));

            return Ok(ApiResponse.SuccessResponse(result.Message));
        }
    }
}

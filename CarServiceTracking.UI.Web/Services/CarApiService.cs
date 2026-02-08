using System.Net.Http;
using System.Net.Http.Json;
using CarServiceTracking.UI.Web.Models.ApiModels;
using CarServiceTracking.UI.Web.ViewModels.Cars;
using CarServiceTracking.UI.Web.Models.ApiModels.CarApiModels;

namespace CarServiceTracking.UI.Web.Services
{
    public class CarApiService
    {
        private readonly HttpClient _client;

        public CarApiService(IHttpClientFactory httpClientFactory)
        {
            // ✅ BaseAddress ayarlı "api" client
            _client = httpClientFactory.CreateClient("api");
        }

        // ✅ GET: api/Cars
        public async Task<List<CarListVM>> GetAllCarsAsync(string? searchTerm = null)
        {
            var url = string.IsNullOrWhiteSpace(searchTerm) 
                ? "api/Cars" 
                : $"api/Cars?search={Uri.EscapeDataString(searchTerm)}";

            var response = await _client.GetFromJsonAsync<ApiResponse<List<CarListApiModel>>>(url);

            if (response == null || !response.Success || response.Data == null)
                return new List<CarListVM>();

            // DTO → VM mapping
            return response.Data.Select(dto => new CarListVM
            {
                Id = dto.Id,
                PlateNumber = dto.PlateNumber,
                Brand = dto.Brand,
                Model = dto.Model,
                BrandModel = dto.BrandModel,
                Year = dto.Year,
                Color = dto.Color,
                Mileage = dto.Mileage,
                CustomerId = dto.CustomerId,
                CustomerName = dto.CustomerName,
                FuelTypeName = dto.FuelTypeName,
                TransmissionTypeName = dto.TransmissionTypeName,
                CarTypeName = dto.CarTypeName,
                IsActive = dto.IsActive,
                CreatedDate = dto.CreatedDate
            }).ToList();
        }

        // ✅ GET: api/Cars/{id}
        public async Task<CarDetailVM?> GetCarByIdAsync(int id)
        {
            var response =
                await _client.GetFromJsonAsync<ApiResponse<CarDetailVM>>($"api/Cars/{id}");

            if (response == null || !response.Success)
                return null;

            return response.Data;
        }

        // ✅ POST: api/Cars
        public async Task<bool> CreateCarAsync(CarCreateVM model)
        {
            try
            {
                // VM'yi DTO'ya dönüştür
                var dto = new CarCreateApiModel
                {
                    PlateNumber = model.PlateNumber,
                    Brand = model.Brand,
                    Model = model.CarModel,
                    Year = model.Year,
                    Color = model.Color,
                    ChassisNumber = model.ChassisNumber,
                    Mileage = model.Mileage,
                    EngineNumber = model.EngineNumber,
                    Notes = model.Notes,
                    CustomerId = model.CustomerId,
                    FuelTypeId = model.FuelTypeId,
                    TransmissionTypeId = model.TransmissionTypeId,
                    CarTypeId = model.CarTypeId
                };

                var response = await _client.PostAsJsonAsync("api/Cars", dto);
                
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
                return result?.Success ?? false;
            }
            catch
            {
                return false;
            }
        }

        // ✅ PUT: api/Cars
        public async Task<bool> UpdateCarAsync(CarUpdateVM model)
        {
            // VM'yi DTO'ya dönüştür
            var dto = new CarUpdateApiModel
            {
                Id = model.Id,
                PlateNumber = model.PlateNumber,
                Brand = model.Brand,
                Model = model.CarModel,
                Year = model.Year,
                Color = model.Color,
                ChassisNumber = model.ChassisNumber,
                Mileage = model.Mileage,
                EngineNumber = model.EngineNumber,
                Notes = model.Notes,
                CustomerId = model.CustomerId,
                FuelTypeId = model.FuelTypeId,
                TransmissionTypeId = model.TransmissionTypeId,
                CarTypeId = model.CarTypeId
            };

            var response = await _client.PutAsJsonAsync("api/Cars", dto);
            
            if (!response.IsSuccessStatusCode)
                return false;

            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            return result?.Success ?? false;
        }

        // ✅ DELETE: api/Cars/{id}
        public async Task<bool> DeleteCarAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/Cars/{id}");
            
            if (!response.IsSuccessStatusCode)
                return false;

            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            return result?.Success ?? false;
        }
    }
}

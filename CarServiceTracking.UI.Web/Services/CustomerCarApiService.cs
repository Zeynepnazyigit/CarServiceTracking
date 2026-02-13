using System.Net.Http.Json;
using CarServiceTracking.UI.Web.ViewModels.CustomerCars;
using CarServiceTracking.UI.Web.Models.ApiModels.CustomerCarApiModels;

namespace CarServiceTracking.UI.Web.Services
{
    public class CustomerCarApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerCarApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<CustomerCarVM>> GetAllAsync()
        {
            var client = _httpClientFactory.CreateClient("api");
            var response = await client.GetAsync("api/CustomerCars/all");

            if (!response.IsSuccessStatusCode)
                return new List<CustomerCarVM>();

            var dtoList = await response.Content
                .ReadFromJsonAsync<List<CustomerCarListApiModel>>()
                ?? new List<CustomerCarListApiModel>();

            return dtoList.Select(x => new CustomerCarVM
            {
                Id = x.Id,
                BrandModel = x.BrandModel,
                PlateNumber = x.PlateNumber,
                Year = x.Year,
                Mileage = x.Mileage,
                Color = x.Color,
                IsInService = x.IsInService
            }).ToList();
        }

        public async Task<List<CustomerCarVM>> GetByCustomerIdAsync(int customerId)
        {
            var client = _httpClientFactory.CreateClient("api");

            var response = await client.GetAsync(
                $"api/CustomerCars?customerId={customerId}");

            if (!response.IsSuccessStatusCode)
                return new List<CustomerCarVM>();

            //  ÖNCE DTO OKU
            var dtoList = await response.Content
                .ReadFromJsonAsync<List<CustomerCarListApiModel>>()
                ?? new List<CustomerCarListApiModel>();

            //  DTO → VM MAP
            return dtoList.Select(x => new CustomerCarVM
            {
                Id = x.Id,
                BrandModel = x.BrandModel,
                PlateNumber = x.PlateNumber,
                Year = x.Year,
                Mileage = x.Mileage,
                Color = x.Color,
                IsInService = x.IsInService
            }).ToList();
        }

        public async Task<CustomerCarVM?> GetByIdAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("api");

            var response = await client.GetAsync($"api/CustomerCars/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var dto = await response.Content
                .ReadFromJsonAsync<CustomerCarListApiModel>();

            if (dto == null) return null;

            return new CustomerCarVM
            {
                Id = dto.Id,
                BrandModel = dto.BrandModel,
                PlateNumber = dto.PlateNumber,
                Year = dto.Year,
                Mileage = dto.Mileage,
                Color = dto.Color,
                IsInService = dto.IsInService
            };
        }

        public async Task<bool> CreateAsync(CustomerCarCreateVM model)
        {
            var client = _httpClientFactory.CreateClient("api");

            var response = await client.PostAsJsonAsync(
                "api/CustomerCars", model);

            return response.IsSuccessStatusCode;
        }
    }
}

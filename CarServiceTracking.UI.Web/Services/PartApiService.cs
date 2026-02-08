using System.Net.Http.Json;
using CarServiceTracking.UI.Web.Models.ApiModels;
using CarServiceTracking.UI.Web.Models.ApiModels.PartApiModels;
using CarServiceTracking.UI.Web.ViewModels.Parts;

namespace CarServiceTracking.UI.Web.Services
{
    public class PartApiService
    {
        private readonly HttpClient _client;

        public PartApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("api");
        }

        public async Task<List<PartListVM>> GetAllAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<PartListApiModel>>>("api/Parts");
            if (response == null || !response.Success || response.Data == null)
                return new List<PartListVM>();

            // DTO → VM Mapping: PartName → Name
            return response.Data.Select(dto => new PartListVM
            {
                Id = dto.Id,
                PartCode = dto.PartCode,
                Name = dto.PartName,
                Category = dto.Category ?? string.Empty,
                UnitPrice = dto.UnitPrice,
                StockQuantity = dto.StockQuantity,
                MinStockLevel = dto.MinStockLevel,
                IsActive = dto.IsActive
            }).ToList();
        }

        public async Task<List<PartListVM>> GetLowStockAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<PartListApiModel>>>("api/Parts/low-stock");
            if (response == null || !response.Success || response.Data == null)
                return new List<PartListVM>();

            return response.Data.Select(dto => new PartListVM
            {
                Id = dto.Id,
                PartCode = dto.PartCode,
                Name = dto.PartName,
                Category = dto.Category ?? string.Empty,
                UnitPrice = dto.UnitPrice,
                StockQuantity = dto.StockQuantity,
                MinStockLevel = dto.MinStockLevel,
                IsActive = dto.IsActive
            }).ToList();
        }

        public async Task<List<PartListVM>> GetByCategoryAsync(string category)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<PartListApiModel>>>($"api/Parts/category/{category}");
            if (response == null || !response.Success || response.Data == null)
                return new List<PartListVM>();

            return response.Data.Select(dto => new PartListVM
            {
                Id = dto.Id,
                PartCode = dto.PartCode,
                Name = dto.PartName,
                Category = dto.Category ?? string.Empty,
                UnitPrice = dto.UnitPrice,
                StockQuantity = dto.StockQuantity,
                MinStockLevel = dto.MinStockLevel,
                IsActive = dto.IsActive
            }).ToList();
        }

        public async Task<List<PartDropdownVM>> GetForDropdownAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<PartListApiModel>>>("api/Parts");
            if (response == null || !response.Success || response.Data == null)
                return new List<PartDropdownVM>();

            return response.Data.Where(p => p.IsActive).Select(dto => new PartDropdownVM
            {
                Id = dto.Id,
                Name = dto.PartName,
                PartCode = dto.PartCode,
                UnitPrice = dto.UnitPrice,
                StockQuantity = dto.StockQuantity
            }).ToList();
        }

        public async Task<PartEditVM?> GetByIdAsync(int id)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<PartDetailApiModel>>($"api/Parts/{id}");
            if (response == null || !response.Success || response.Data == null)
                return null;

            return new PartEditVM
            {
                Id = response.Data.Id,
                PartCode = response.Data.PartCode,
                Name = response.Data.PartName,
                Category = response.Data.Category ?? string.Empty,
                Description = response.Data.Description,
                UnitPrice = response.Data.UnitPrice,
                StockQuantity = response.Data.StockQuantity,
                MinStockLevel = response.Data.MinStockLevel,
                IsActive = response.Data.IsActive
            };
        }

        public async Task<(bool Success, string Message)> CreateAsync(PartCreateVM vm)
        {
            // VM → DTO Mapping: Name → PartName
            var dto = new PartCreateApiModel
            {
                PartCode = vm.PartCode,
                PartName = vm.Name,
                Category = vm.Category,
                Description = vm.Description,
                UnitPrice = vm.UnitPrice,
                StockQuantity = vm.StockQuantity,
                MinStockLevel = vm.MinStockLevel,
                IsActive = vm.IsActive
            };

            var response = await _client.PostAsJsonAsync("api/Parts", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<PartDetailApiModel>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Parça oluşturulamadı");
        }

        public async Task<(bool Success, string Message)> UpdateAsync(PartEditVM vm)
        {
            var dto = new PartUpdateApiModel
            {
                Id = vm.Id,
                PartCode = vm.PartCode,
                PartName = vm.Name,
                Category = vm.Category,
                Description = vm.Description,
                UnitPrice = vm.UnitPrice,
                StockQuantity = vm.StockQuantity,
                MinStockLevel = vm.MinStockLevel,
                IsActive = vm.IsActive
            };

            var response = await _client.PutAsJsonAsync($"api/Parts/{vm.Id}", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<PartDetailApiModel>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Parça güncellenemedi");
        }

        public async Task<(bool Success, string Message)> UpdateStockAsync(int id, int quantity, string reason)
        {
            var dto = new { Quantity = quantity, Reason = reason };
            var response = await _client.PatchAsJsonAsync($"api/Parts/{id}/stock", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Stok güncellenemedi");
        }

        public async Task<(bool Success, string Message)> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/Parts/{id}");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Parça silinemedi");
        }
    }
}

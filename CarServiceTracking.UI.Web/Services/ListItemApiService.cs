using System.Net.Http.Json;
using CarServiceTracking.UI.Web.Models.ApiModels;
using CarServiceTracking.UI.Web.Models.ApiModels.ListItemApiModels;
using CarServiceTracking.UI.Web.ViewModels.ListItems;

namespace CarServiceTracking.UI.Web.Services
{
    public class ListItemApiService
    {
        private readonly HttpClient _client;

        public ListItemApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("api");
        }

        /// <summary>
        /// Dropdown için tip'e göre liste öğelerini getir (FuelType, TransmissionType, CarType, CustomerType)
        /// </summary>
        public async Task<List<ListItemDropdownVM>> GetDropdownByTypeAsync(string listType)
        {
            var url = $"api/ListItems/type/{listType}";

            var response = await _client.GetFromJsonAsync<ApiResponse<List<ListItemListApiModel>>>(url);

            if (response == null || !response.Success || response.Data == null)
                return new List<ListItemDropdownVM>();

            // DTO → Dropdown VM mapping
            return response.Data.Select(dto => new ListItemDropdownVM
            {
                Id = dto.Id,
                Name = dto.Name
            }).ToList();
        }

        /// <summary>
        /// Admin: Tüm liste öğelerini getir
        /// </summary>
        public async Task<List<ListItemListVM>> GetAllAsync()
        {
            var url = "api/ListItems";

            var response = await _client.GetFromJsonAsync<ApiResponse<List<ListItemListApiModel>>>(url);

            if (response == null || !response.Success || response.Data == null)
                return new List<ListItemListVM>();

            // DTO → VM mapping
            return response.Data.Select(dto => new ListItemListVM
            {
                Id = dto.Id,
                Name = dto.Name,
                ListType = dto.ListType,
                ParentId = dto.ParentId,
                ParentName = dto.ParentName,
                SortOrder = dto.SortOrder,
                IsActive = dto.IsActive
            }).ToList();
        }

        /// <summary>
        /// Admin: Detay getir
        /// </summary>
        public async Task<ListItemEditVM?> GetByIdAsync(int id)
        {
            var url = $"api/ListItems/{id}";

            var response = await _client.GetFromJsonAsync<ApiResponse<ListItemDetailApiModel>>(url);

            if (response == null || !response.Success || response.Data == null)
                return null;

            // DTO → Edit VM mapping
            return new ListItemEditVM
            {
                Id = response.Data.Id,
                Name = response.Data.Name,
                ListType = response.Data.ListType,
                ParentId = response.Data.ParentId,
                SortOrder = response.Data.SortOrder,
                IsActive = response.Data.IsActive,
                Description = response.Data.Description
            };
        }

        /// <summary>
        /// Admin: Yeni liste öğesi oluştur
        /// </summary>
        public async Task<(bool Success, string Message)> CreateAsync(ListItemCreateVM vm)
        {
            var dto = new ListItemCreateApiModel
            {
                Name = vm.Name,
                ListType = vm.ListType,
                ParentId = vm.ParentId,
                SortOrder = vm.SortOrder,
                IsActive = vm.IsActive,
                Description = vm.Description
            };

            var response = await _client.PostAsJsonAsync("api/ListItems", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<ListItemDetailApiModel>>();

            if (result != null && result.Success)
                return (true, result.Message);

            return (false, result?.Message ?? "Liste öğesi oluşturulamadı");
        }

        /// <summary>
        /// Admin: Liste öğesi güncelle
        /// </summary>
        public async Task<(bool Success, string Message)> UpdateAsync(ListItemEditVM vm)
        {
            var dto = new ListItemUpdateApiModel
            {
                Id = vm.Id,
                Name = vm.Name,
                ListType = vm.ListType,
                ParentId = vm.ParentId,
                SortOrder = vm.SortOrder,
                IsActive = vm.IsActive,
                Description = vm.Description
            };

            var response = await _client.PutAsJsonAsync($"api/ListItems/{vm.Id}", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<ListItemDetailApiModel>>();

            if (result != null && result.Success)
                return (true, result.Message);

            return (false, result?.Message ?? "Liste öğesi güncellenemedi");
        }

        /// <summary>
        /// Admin: Liste öğesi sil
        /// </summary>
        public async Task<(bool Success, string Message)> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/ListItems/{id}");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();

            if (result != null && result.Success)
                return (true, result.Message);

            return (false, result?.Message ?? "Liste öğesi silinemedi");
        }
    }
}

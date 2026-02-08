using System.Net.Http.Json;
using CarServiceTracking.UI.Web.Models.ApiModels;
using CarServiceTracking.UI.Web.Models.ApiModels.MechanicApiModels;
using CarServiceTracking.UI.Web.ViewModels.Mechanics;

namespace CarServiceTracking.UI.Web.Services
{
    public class MechanicApiService
    {
        private readonly HttpClient _client;

        public MechanicApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("api");
        }

        public async Task<List<MechanicListVM>> GetAllAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<MechanicListApiModel>>>("api/Mechanics");
            if (response == null || !response.Success || response.Data == null)
                return new List<MechanicListVM>();

            // DTO → VM Mapping: FullName split, Phone → PhoneNumber
            return response.Data.Select(dto =>
            {
                var nameParts = dto.FullName.Split(' ', 2);
                return new MechanicListVM
                {
                    Id = dto.Id,
                    FirstName = nameParts.Length > 0 ? nameParts[0] : string.Empty,
                    LastName = nameParts.Length > 1 ? nameParts[1] : string.Empty,
                    Specialization = dto.Specialization ?? string.Empty,
                    PhoneNumber = dto.Phone,
                    IsActive = dto.IsAvailable // IsAvailable → IsActive
                };
            }).ToList();
        }

        public async Task<List<MechanicListVM>> GetAvailableAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<MechanicListApiModel>>>("api/Mechanics/available");
            if (response == null || !response.Success || response.Data == null)
                return new List<MechanicListVM>();

            return response.Data.Select(dto =>
            {
                var nameParts = dto.FullName.Split(' ', 2);
                return new MechanicListVM
                {
                    Id = dto.Id,
                    FirstName = nameParts.Length > 0 ? nameParts[0] : string.Empty,
                    LastName = nameParts.Length > 1 ? nameParts[1] : string.Empty,
                    Specialization = dto.Specialization ?? string.Empty,
                    PhoneNumber = dto.Phone,
                    IsActive = dto.IsAvailable
                };
            }).ToList();
        }

        public async Task<List<MechanicListVM>> GetBySpecializationAsync(string specialization)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<MechanicListApiModel>>>($"api/Mechanics/specialization/{specialization}");
            if (response == null || !response.Success || response.Data == null)
                return new List<MechanicListVM>();

            return response.Data.Select(dto =>
            {
                var nameParts = dto.FullName.Split(' ', 2);
                return new MechanicListVM
                {
                    Id = dto.Id,
                    FirstName = nameParts.Length > 0 ? nameParts[0] : string.Empty,
                    LastName = nameParts.Length > 1 ? nameParts[1] : string.Empty,
                    Specialization = dto.Specialization ?? string.Empty,
                    PhoneNumber = dto.Phone,
                    IsActive = dto.IsAvailable
                };
            }).ToList();
        }

        public async Task<List<MechanicDropdownVM>> GetForDropdownAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<MechanicListApiModel>>>("api/Mechanics");
            if (response == null || !response.Success || response.Data == null)
                return new List<MechanicDropdownVM>();

            return response.Data.Where(m => m.IsAvailable).Select(dto =>
            {
                var nameParts = dto.FullName.Split(' ', 2);
                return new MechanicDropdownVM
                {
                    Id = dto.Id,
                    FirstName = nameParts.Length > 0 ? nameParts[0] : string.Empty,
                    LastName = nameParts.Length > 1 ? nameParts[1] : string.Empty,
                    Specialization = dto.Specialization ?? string.Empty
                };
            }).ToList();
        }

        public async Task<MechanicEditVM?> GetByIdAsync(int id)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<MechanicDetailApiModel>>($"api/Mechanics/{id}");
            if (response == null || !response.Success || response.Data == null)
                return null;

            // DetailDTO has FirstName/LastName directly
            return new MechanicEditVM
            {
                Id = response.Data.Id,
                FirstName = response.Data.FirstName,
                LastName = response.Data.LastName,
                Specialization = response.Data.Specialization ?? string.Empty,
                PhoneNumber = response.Data.Phone,
                Email = response.Data.Email,
                IsActive = response.Data.IsAvailable
            };
        }

        public async Task<(bool Success, string Message)> CreateAsync(MechanicCreateVM vm)
        {
            // VM → DTO Mapping: PhoneNumber → Phone
            var dto = new MechanicCreateApiModel
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Specialization = vm.Specialization,
                Phone = vm.PhoneNumber,
                Email = vm.Email ?? string.Empty,
                HourlyRate = 0, // Default, VM'de yok
                IsAvailable = vm.IsActive
            };

            var response = await _client.PostAsJsonAsync("api/Mechanics", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<MechanicDetailApiModel>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Mekaniker oluşturulamadı");
        }

        public async Task<(bool Success, string Message)> UpdateAsync(MechanicEditVM vm)
        {
            var dto = new MechanicUpdateApiModel
            {
                Id = vm.Id,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Specialization = vm.Specialization,
                Phone = vm.PhoneNumber,
                Email = vm.Email ?? string.Empty,
                IsAvailable = vm.IsActive
            };

            var response = await _client.PutAsJsonAsync($"api/Mechanics/{vm.Id}", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<MechanicDetailApiModel>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Mekaniker güncellenemedi");
        }

        public async Task<(bool Success, string Message)> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/Mechanics/{id}");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Mekaniker silinemedi");
        }
    }
}

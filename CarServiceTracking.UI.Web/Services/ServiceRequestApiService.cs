using System.Net.Http.Json;
using CarServiceTracking.UI.Web.Models.ApiModels;
using CarServiceTracking.UI.Web.Models.ApiModels.ServiceRequestApiModels;
using CarServiceTracking.UI.Web.ViewModels.ServiceRequests;

namespace CarServiceTracking.UI.Web.Services
{
    public class ServiceRequestApiService
    {
        private readonly HttpClient _client;

        public ServiceRequestApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("api");
        }

        public async Task<List<ServiceRequestListVM>> GetAllAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<ServiceRequestListApiModel>>>("api/ServiceRequests");

            if (response == null || !response.Success || response.Data == null)
                return new List<ServiceRequestListVM>();

            return response.Data.Select(dto => new ServiceRequestListVM
            {
                Id = dto.Id,
                CarId = dto.CarId,
                CarName = dto.CarName,
                ProblemDescription = dto.ProblemDescription,
                Status = dto.Status,
                StatusText = GetStatusText(dto.Status),
                CreatedAt = dto.CreatedAt,
                PreferredDate = dto.PreferredDate
            }).ToList();
        }

        public async Task<ServiceRequestDetailVM?> GetByIdAsync(int id)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<ServiceRequestDetailApiModel>>($"api/ServiceRequests/{id}");

            if (response == null || !response.Success || response.Data == null)
                return null;

            var dto = response.Data;
            return new ServiceRequestDetailVM
            {
                Id = dto.Id,
                CarId = dto.CarId,
                CarName = dto.CarName ?? "",
                ProblemDescription = dto.ProblemDescription,
                PreferredDate = dto.PreferredDate,
                Status = (int)dto.Status,
                StatusText = GetStatusText((int)dto.Status),
                ServicePrice = dto.ServicePrice,
                AdminNote = dto.AdminNote,
                CreatedAt = dto.CreatedAt
            };
        }

        public async Task<bool> CreateAsync(ServiceRequestCreateVM model, int customerId)
        {
            try
            {
                var dto = new ServiceRequestCreateApiModel
                {
                    CustomerId = customerId,
                    CarId = model.CarId,
                    ProblemDescription = model.ProblemDescription,
                    PreferredDate = model.PreferredDate
                };

                var response = await _client.PostAsJsonAsync("api/ServiceRequests", dto);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    // API hata döndü
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

        public async Task<bool> UpdateStatusAsync(int id, ServiceRequestUpdateStatusVM model)
        {
            try
            {
                var dto = new
                {
                    Status = model.Status,
                    ServicePrice = model.ServicePrice,
                    AdminNote = model.AdminNote
                };

                var response = await _client.PutAsJsonAsync($"api/ServiceRequests/{id}/status", dto);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    // API hata döndü
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

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _client.DeleteAsync($"api/ServiceRequests/{id}");

                if (!response.IsSuccessStatusCode)
                    return false;

                var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
                return result?.Success ?? false;
            }
            catch
            {
                return false;
            }
        }

        private string GetStatusText(int status)
        {
            return status switch
            {
                0 => "Beklemede",
                1 => "İşlemde",
                2 => "Tamamlandı",
                3 => "İptal Edildi",
                _ => "Bilinmiyor"
            };
        }
    }
}

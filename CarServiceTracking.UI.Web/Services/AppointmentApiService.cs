using System.Net.Http.Json;
using CarServiceTracking.UI.Web.Models.ApiModels;
using CarServiceTracking.UI.Web.Models.ApiModels.AppointmentApiModels;
using CarServiceTracking.UI.Web.ViewModels.Appointments;

namespace CarServiceTracking.UI.Web.Services
{
    public class AppointmentApiService
    {
        private readonly HttpClient _client;

        public AppointmentApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("api");
        }

        public async Task<List<AppointmentListVM>> GetAllAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<AppointmentListApiModel>>>("api/Appointments");
            if (response == null || !response.Success || response.Data == null)
                return new List<AppointmentListVM>();

            // DTO → VM Mapping: ServiceType → RequestedService, Status enum → string
            return response.Data.Select(dto => new AppointmentListVM
            {
                Id = dto.Id,
                CustomerId = dto.CustomerId,
                CustomerName = dto.CustomerName,
                CarId = dto.CarId,
                CarInfo = dto.CarInfo,
                AppointmentDate = dto.AppointmentDate,
                RequestedService = dto.ServiceType ?? string.Empty,
                Status = dto.Status.ToString(),
                Notes = null // ListDTO'da yok
            }).ToList();
        }

        public async Task<List<AppointmentListVM>> GetByDateAsync(DateTime date)
        {
            var dateStr = date.ToString("yyyy-MM-dd");
            var response = await _client.GetFromJsonAsync<ApiResponse<List<AppointmentListApiModel>>>($"api/Appointments/date/{dateStr}");
            if (response == null || !response.Success || response.Data == null)
                return new List<AppointmentListVM>();

            return response.Data.Select(dto => new AppointmentListVM
            {
                Id = dto.Id,
                CustomerId = dto.CustomerId,
                CustomerName = dto.CustomerName,
                CarId = dto.CarId,
                CarInfo = dto.CarInfo,
                AppointmentDate = dto.AppointmentDate,
                RequestedService = dto.ServiceType ?? string.Empty,
                Status = dto.Status.ToString(),
                Notes = null
            }).ToList();
        }

        public async Task<List<AppointmentListVM>> GetByStatusAsync(string status)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<AppointmentListApiModel>>>($"api/Appointments/status/{status}");
            if (response == null || !response.Success || response.Data == null)
                return new List<AppointmentListVM>();

            return response.Data.Select(dto => new AppointmentListVM
            {
                Id = dto.Id,
                CustomerId = dto.CustomerId,
                CustomerName = dto.CustomerName,
                CarId = dto.CarId,
                CarInfo = dto.CarInfo,
                AppointmentDate = dto.AppointmentDate,
                RequestedService = dto.ServiceType ?? string.Empty,
                Status = dto.Status.ToString(),
                Notes = null
            }).ToList();
        }

        public async Task<List<AppointmentListVM>> GetByCustomerIdAsync(int customerId)
        {
            try
            {
                var response = await _client.GetFromJsonAsync<ApiResponse<List<AppointmentListApiModel>>>($"api/Appointments/customer/{customerId}");
                if (response == null || !response.Success || response.Data == null)
                    return new List<AppointmentListVM>();

                return response.Data.Select(dto => new AppointmentListVM
            {
                Id = dto.Id,
                CustomerId = dto.CustomerId,
                CustomerName = dto.CustomerName,
                CarId = dto.CarId,
                CarInfo = dto.CarInfo,
                AppointmentDate = dto.AppointmentDate,
                RequestedService = dto.ServiceType ?? string.Empty,
                Status = dto.Status.ToString(),
                Notes = null
            }).ToList();
            }
            catch (HttpRequestException)
            {
                // API 500 veya network hatası - boş liste dön, sayfa çökmesin
                return new List<AppointmentListVM>();
            }
        }

        public async Task<AppointmentEditVM?> GetByIdAsync(int id)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<AppointmentDetailApiModel>>($"api/Appointments/{id}");
            if (response == null || !response.Success || response.Data == null)
                return null;

            // DetailDTO: ServiceType, CustomerNotes, Description, AdminNotes → EditVM
            return new AppointmentEditVM
            {
                Id = response.Data.Id,
                CustomerId = response.Data.CustomerId,
                CarId = response.Data.CarId,
                AppointmentDate = response.Data.AppointmentDate,
                TimeSlot = response.Data.TimeSlot ?? "09:00-10:00",
                RequestedService = response.Data.ServiceType ?? string.Empty,
                Status = response.Data.Status.ToString(),
                Description = response.Data.Description,
                CustomerNotes = response.Data.CustomerNotes,
                AdminNotes = response.Data.AdminNotes,
                CustomerName = response.Data.CustomerName ?? string.Empty,
                CarInfo = response.Data.CarInfo ?? string.Empty
            };
        }

        public async Task<(bool Success, string Message)> CreateAsync(AppointmentCreateVM vm)
        {
            // VM → DTO Mapping
            var dto = new AppointmentCreateApiModel
            {
                CustomerId = vm.CustomerId,
                CarId = vm.CarId,
                CustomerCarId = vm.CustomerCarId,
                AppointmentDate = vm.AppointmentDate,
                TimeSlot = vm.TimeSlot,
                ServiceType = vm.RequestedService,
                Description = vm.Description,
                CustomerNotes = vm.CustomerNotes
            };

            var response = await _client.PostAsJsonAsync("api/Appointments", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<AppointmentDetailApiModel>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Randevu oluşturulamadı");
        }

        public async Task<(bool Success, string Message)> UpdateAsync(AppointmentEditVM vm)
        {
            // Parse status string back to enum
            if (!Enum.TryParse<Enums.AppointmentStatus>(vm.Status, out var status))
                status = Enums.AppointmentStatus.Pending;

            // VM → DTO: Update DTO'da CustomerNotes yok (sadece Create'te var)
            var dto = new AppointmentUpdateApiModel
            {
                Id = vm.Id,
                AppointmentDate = vm.AppointmentDate,
                TimeSlot = vm.TimeSlot,
                Status = status,
                ServiceType = vm.RequestedService,
                Description = vm.Description,
                AdminNotes = vm.AdminNotes
            };

            var response = await _client.PutAsJsonAsync($"api/Appointments/{vm.Id}", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<AppointmentDetailApiModel>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Randevu güncellenemedi");
        }

        public async Task<(bool Success, string Message)> ConfirmAsync(int id)
        {
            var response = await _client.PostAsync($"api/Appointments/{id}/confirm", null);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Randevu onaylanamadı");
        }

        public async Task<(bool Success, string Message)> CancelAsync(int id, string cancellationReason)
        {
            var dto = new { CancellationReason = cancellationReason };
            var response = await _client.PostAsJsonAsync($"api/Appointments/{id}/cancel", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Randevu iptal edilemedi");
        }

        public async Task<(bool Success, string Message)> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/Appointments/{id}");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Randevu silinemedi");
        }
    }
}

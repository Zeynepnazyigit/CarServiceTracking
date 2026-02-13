using System.Net.Http.Json;
using CarServiceTracking.UI.Web.Models.ApiModels;
using CarServiceTracking.UI.Web.Models.ApiModels.ServiceAssignmentApiModels;
using CarServiceTracking.UI.Web.ViewModels.ServiceAssignments;

namespace CarServiceTracking.UI.Web.Services
{
    public class ServiceAssignmentApiService
    {
        private readonly HttpClient _client;

        public ServiceAssignmentApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("api");
        }

        public async Task<List<ServiceAssignmentVM>> GetByServiceRequestIdAsync(int serviceRequestId)
        {
            try
            {
                var response = await _client.GetFromJsonAsync<ApiResponse<List<ServiceAssignmentListApiModel>>>(
                    $"api/ServiceRequests/{serviceRequestId}/assignments");

                if (response == null || !response.Success || response.Data == null)
                    return new List<ServiceAssignmentVM>();

                return response.Data.Select(dto => new ServiceAssignmentVM
                {
                    Id = dto.Id,
                    ServiceRequestId = dto.ServiceRequestId,
                    MechanicId = dto.MechanicId,
                    MechanicName = dto.MechanicName,
                    Specialization = dto.Specialization,
                    AssignedAt = dto.AssignedAt,
                    StartedAt = dto.StartedAt,
                    CompletedAt = dto.CompletedAt,
                    EstimatedHours = dto.EstimatedHours,
                    ActualHours = dto.ActualHours,
                    Notes = dto.Notes
                }).ToList();
            }
            catch
            {
                return new List<ServiceAssignmentVM>();
            }
        }

        public async Task<(bool Success, string Message)> AssignAsync(int serviceRequestId, ServiceAssignmentCreateVM model)
        {
            try
            {
                var dto = new
                {
                    MechanicId = model.MechanicId,
                    EstimatedHours = model.EstimatedHours,
                    Notes = model.Notes
                };

                var response = await _client.PostAsJsonAsync(
                    $"api/ServiceRequests/{serviceRequestId}/assignments", dto);

                var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();

                if (result != null && result.Success)
                    return (true, result.Message ?? "Teknisyen atandi.");

                return (false, result?.Message ?? "Teknisyen atanamadi.");
            }
            catch
            {
                return (false, "Bir hata olustu.");
            }
        }

        public async Task<(bool Success, string Message)> RemoveAsync(int serviceRequestId, int assignmentId)
        {
            try
            {
                var response = await _client.DeleteAsync(
                    $"api/ServiceRequests/{serviceRequestId}/assignments/{assignmentId}");

                var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();

                if (result != null && result.Success)
                    return (true, result.Message ?? "Atama kaldirildi.");

                return (false, result?.Message ?? "Atama kaldirilamadi.");
            }
            catch
            {
                return (false, "Bir hata olustu.");
            }
        }
    }
}

using System.Net.Http.Json;
using System.Net.Http.Headers;
using CarServiceTracking.UI.Web.Models.ApiModels;
using CarServiceTracking.UI.Web.Models.ApiModels.InvoiceApiModels;
using CarServiceTracking.UI.Web.ViewModels.Invoices;
using Microsoft.AspNetCore.Http;

namespace CarServiceTracking.UI.Web.Services
{
    public class InvoiceApiService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InvoiceApiService(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _client = httpClientFactory.CreateClient("api");
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetToken() => _httpContextAccessor.HttpContext?.Session.GetString("AccessToken");

        private void AddAuthorizationHeader(HttpRequestMessage request)
        {
            var token = GetToken();
            if (!string.IsNullOrEmpty(token))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<InvoiceListVM>> GetAllAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<InvoiceListApiModel>>>("api/Invoices");

            if (response == null || !response.Success || response.Data == null)
                return new List<InvoiceListVM>();

            return response.Data.Select(dto => new InvoiceListVM
            {
                Id = dto.Id,
                InvoiceNumber = dto.InvoiceNumber,
                ServiceRequestId = dto.ServiceRequestId,
                ServiceRequestInfo = dto.CustomerName,
                InvoiceDate = dto.InvoiceDate,
                TotalAmount = dto.TotalAmount,
                PaidAmount = dto.PaidAmount,
                RemainingAmount = dto.RemainingAmount,
                PaymentStatus = dto.PaymentStatus.ToString()
            }).ToList();
        }

        public async Task<List<InvoiceListVM>> GetByCustomerIdAsync(int customerId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Invoices/customer/{customerId}");
            AddAuthorizationHeader(request);
            var response = await _client.SendAsync(request);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<InvoiceListApiModel>>>();

            if (result == null || !result.Success || result.Data == null)
                return new List<InvoiceListVM>();

            return result.Data.Select(dto => new InvoiceListVM
            {
                Id = dto.Id,
                InvoiceNumber = dto.InvoiceNumber,
                ServiceRequestId = dto.ServiceRequestId,
                RentalAgreementId = dto.RentalAgreementId,
                ServiceRequestInfo = dto.CustomerName,
                RentalInfo = dto.RentalInfo,
                InvoiceDate = dto.InvoiceDate,
                TotalAmount = dto.TotalAmount,
                PaidAmount = dto.PaidAmount,
                RemainingAmount = dto.RemainingAmount,
                PaymentStatus = dto.PaymentStatus.ToString()
            }).ToList();
        }

        public async Task<List<InvoiceListVM>> GetPendingByCustomerIdAsync(int customerId)
        {
            var allInvoices = await GetByCustomerIdAsync(customerId);

            return allInvoices
                .Where(i => i.RemainingAmount > 0 && i.PaymentStatus != "Paid")
                .ToList();
        }

        public async Task<List<InvoiceListVM>> GetOverdueAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<InvoiceListApiModel>>>("api/Invoices/overdue");

            if (response == null || !response.Success || response.Data == null)
                return new List<InvoiceListVM>();

            return response.Data.Select(dto => new InvoiceListVM
            {
                Id = dto.Id,
                InvoiceNumber = dto.InvoiceNumber,
                ServiceRequestId = dto.ServiceRequestId,
                ServiceRequestInfo = dto.CustomerName,
                InvoiceDate = dto.InvoiceDate,
                TotalAmount = dto.TotalAmount,
                PaidAmount = dto.PaidAmount,
                RemainingAmount = dto.RemainingAmount,
                PaymentStatus = dto.PaymentStatus.ToString()
            }).ToList();
        }

        public async Task<InvoiceEditVM?> GetByIdAsync(int id)
        {
            var response = await _client
                .GetFromJsonAsync<ApiResponse<InvoiceDetailApiModel>>($"api/Invoices/{id}");

            if (response == null || !response.Success || response.Data == null)
                return null;

            return new InvoiceEditVM
            {
                Id = response.Data.Id,
                InvoiceNumber = response.Data.InvoiceNumber,
                ServiceRequestId = response.Data.ServiceRequestId,
                InvoiceDate = response.Data.InvoiceDate,
                TotalAmount = response.Data.GrandTotal,
                PaidAmount = response.Data.PaidAmount,
                RemainingAmount = response.Data.RemainingAmount,
                Notes = response.Data.Notes
            };
        }

        public async Task<InvoicePdfVM?> GetByIdForPdfAsync(int id)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<InvoiceDetailApiModel>>($"api/Invoices/{id}");

            if (response == null || !response.Success || response.Data == null)
                return null;

            var dto = response.Data;

            return new InvoicePdfVM
            {
                Id = dto.Id,
                InvoiceNumber = dto.InvoiceNumber,
                CustomerName = dto.CustomerName,
                CustomerPhone = dto.CustomerPhone,
                CarInfo = dto.CarInfo,
                InvoiceDate = dto.InvoiceDate,
                DueDate = dto.DueDate,
                LaborCost = dto.LaborCost,
                PartsTotal = dto.PartsTotal,
                SubTotal = dto.SubTotal,
                TaxRate = dto.TaxRate,
                TaxAmount = dto.TaxAmount,
                GrandTotal = dto.GrandTotal,
                PaidAmount = dto.PaidAmount,
                RemainingAmount = dto.RemainingAmount,
                PaymentStatus = dto.PaymentStatus.ToString(),
                Notes = dto.Notes
            };
        }

        public async Task<List<InvoiceListVM>> GetByStatusAsync(string status)
        {
            var allInvoices = await GetAllAsync();
            return allInvoices.Where(i => i.PaymentStatus == status).ToList();
        }

        public async Task<(bool Success, string Message)> UpdateAsync(InvoiceEditVM vm)
        {
            var dto = new InvoiceUpdateApiModel
            {
                Id = vm.Id,
                Notes = vm.Notes
            };

            var response = await _client.PutAsJsonAsync($"api/Invoices/{vm.Id}", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<InvoiceDetailApiModel>>();

            if (result != null && result.Success)
                return (true, result.Message);

            return (false, result?.Message ?? "Fatura güncellenemedi");
        }

        public async Task<(bool Success, string Message)> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/Invoices/{id}");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();

            if (result != null && result.Success)
                return (true, result.Message);

            return (false, result?.Message ?? "Fatura silinemedi");
        }

        public async Task<ApiResponse<InvoiceDetailApiModel>> CreateFromServiceRequestAsync(int serviceRequestId, bool replaceIfExists = false)
        {
            var url = $"api/Invoices/from-service-request/{serviceRequestId}";
            if (replaceIfExists)
                url += "?replace=true";
            var response = await _client.PostAsync(url, null);

            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                var message = TryGetErrorMessageFromJson(errorBody)
                    ?? (string.IsNullOrEmpty(errorBody) ? $"API hatası: {(int)response.StatusCode}" : errorBody);
                return new ApiResponse<InvoiceDetailApiModel> { Success = false, Message = message };
            }

            return await response.Content.ReadFromJsonAsync<ApiResponse<InvoiceDetailApiModel>>()
                ?? new ApiResponse<InvoiceDetailApiModel> { Success = false, Message = "Yanıt okunamadı." };
        }

        /// <summary>
        /// API hata gövdesindeki (JSON) message alanını okur; katmanlı yapıda tutarlı hata gösterimi için.
        /// </summary>
        private static string? TryGetErrorMessageFromJson(string? json)
        {
            if (string.IsNullOrWhiteSpace(json)) return null;
            try
            {
                var doc = System.Text.Json.JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("message", out var msg))
                    return msg.GetString();
            }
            catch { /* ignore */ }
            return null;
        }
    }
}

using System.Net.Http.Json;
using CarServiceTracking.UI.Web.Models.ApiModels;
using CarServiceTracking.UI.Web.Models.ApiModels.InvoiceApiModels;
using CarServiceTracking.UI.Web.ViewModels.Invoices;

namespace CarServiceTracking.UI.Web.Services
{
    public class InvoiceApiService
    {
        private readonly HttpClient _client;

        public InvoiceApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("api");
        }

        public async Task<List<InvoiceListVM>> GetAllAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<InvoiceListApiModel>>>("api/Invoices");
            if (response == null || !response.Success || response.Data == null)
                return new List<InvoiceListVM>();

            // DTO → VM Mapping: CustomerName (not ServiceRequestInfo), PaymentStatus enum → string
            return response.Data.Select(dto => new InvoiceListVM
            {
                Id = dto.Id,
                InvoiceNumber = dto.InvoiceNumber,
                ServiceRequestId = dto.ServiceRequestId,
                ServiceRequestInfo = dto.CustomerName, // Use CustomerName as info
                InvoiceDate = dto.InvoiceDate,
                TotalAmount = dto.TotalAmount,
                PaidAmount = dto.PaidAmount,
                RemainingAmount = dto.RemainingAmount,
                PaymentStatus = dto.PaymentStatus.ToString()
            }).ToList();
        }

        /// <summary>
        /// Müşteriye ait faturaları getirir
        /// </summary>
        public async Task<List<InvoiceListVM>> GetByCustomerIdAsync(int customerId)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<InvoiceListApiModel>>>($"api/Invoices/customer/{customerId}");
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

        public async Task<List<InvoiceListVM>> GetByStatusAsync(string status)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<InvoiceListApiModel>>>($"api/Invoices/status/{status}");
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

        public async Task<InvoiceEditVM?> GetByNumberAsync(string invoiceNumber)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<InvoiceDetailApiModel>>($"api/Invoices/number/{invoiceNumber}");
            if (response == null || !response.Success || response.Data == null)
                return null;

            // DetailDTO: GrandTotal (not TotalAmount)
            return new InvoiceEditVM
            {
                Id = response.Data.Id,
                InvoiceNumber = response.Data.InvoiceNumber,
                ServiceRequestId = response.Data.ServiceRequestId,
                InvoiceDate = response.Data.InvoiceDate,
                TotalAmount = response.Data.GrandTotal,
                PaidAmount = response.Data.PaidAmount,
                Notes = response.Data.Notes
            };
        }

        public async Task<InvoiceEditVM?> GetByIdAsync(int id)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<InvoiceDetailApiModel>>($"api/Invoices/{id}");
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

        public async Task<(bool Success, string Message)> CreateAsync(InvoiceCreateVM vm)
        {
            // VM → DTO Mapping: No InvoiceNumber in CreateDTO
            var dto = new InvoiceCreateApiModel
            {
                ServiceRequestId = vm.ServiceRequestId,
                InvoiceDate = vm.InvoiceDate,
                LaborCost = 0,
                PartsTotal = vm.TotalAmount,
                Notes = vm.Notes
            };

            var response = await _client.PostAsJsonAsync("api/Invoices", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<InvoiceDetailApiModel>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Fatura oluşturulamadı");
        }

        public async Task<(bool Success, string Message, int? InvoiceId)> CreateFromServiceRequestAsync(int serviceRequestId)
        {
            var response = await _client.PostAsync($"api/Invoices/from-service-request/{serviceRequestId}", null);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<InvoiceDetailApiModel>>();
            if (result != null && result.Success && result.Data != null)
                return (true, result.Message, result.Data.Id);
            return (false, result?.Message ?? "Fatura otomatik oluşturulamadı", null);
        }

        public async Task<(bool Success, string Message)> UpdateAsync(InvoiceEditVM vm)
        {
            // InvoiceUpdateDTO doesn't exist - using InvoiceCreateDTO pattern
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
    }
}

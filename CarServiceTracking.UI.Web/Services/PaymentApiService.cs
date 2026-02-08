using System.Net.Http.Json;
using CarServiceTracking.UI.Web.Models.ApiModels;
using CarServiceTracking.UI.Web.Models.ApiModels.PaymentApiModels;
using CarServiceTracking.UI.Web.ViewModels.Payments;

namespace CarServiceTracking.UI.Web.Services
{
    public class PaymentApiService
    {
        private readonly HttpClient _client;

        public PaymentApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("api");
        }

        public async Task<List<PaymentListVM>> GetAllAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<PaymentListApiModel>>>("api/Payments");
            if (response == null || !response.Success || response.Data == null)
                return new List<PaymentListVM>();

            // DTO → VM Mapping: PaymentMethod enum → string, ReferenceNumber → TransactionId
            return response.Data.Select(dto => new PaymentListVM
            {
                Id = dto.Id,
                InvoiceId = dto.InvoiceId,
                InvoiceNumber = dto.InvoiceNumber,
                PaymentDate = dto.PaymentDate,
                Amount = dto.Amount,
                PaymentMethod = dto.PaymentMethod.ToString(),
                TransactionId = dto.ReferenceNumber,
                Notes = null // Not in ListDTO
            }).ToList();
        }

        /// <summary>
        /// Müşteriye ait tüm ödemeleri getirir.
        /// </summary>
        /// <param name="customerId">Müşteri ID</param>
        /// <returns>Müşterinin tüm ödemeleri</returns>
        public async Task<List<PaymentListVM>> GetByCustomerIdAsync(int customerId)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<PaymentListApiModel>>>($"api/Payments/customer/{customerId}");
            if (response == null || !response.Success || response.Data == null)
                return new List<PaymentListVM>();

            return response.Data.Select(dto => new PaymentListVM
            {
                Id = dto.Id,
                InvoiceId = dto.InvoiceId,
                InvoiceNumber = dto.InvoiceNumber,
                PaymentDate = dto.PaymentDate,
                Amount = dto.Amount,
                PaymentMethod = dto.PaymentMethod.ToString(),
                TransactionId = dto.ReferenceNumber,
                Notes = null
            }).ToList();
        }

        public async Task<List<PaymentListVM>> GetByMethodAsync(string method)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<PaymentListApiModel>>>($"api/Payments/method/{method}");
            if (response == null || !response.Success || response.Data == null)
                return new List<PaymentListVM>();

            return response.Data.Select(dto => new PaymentListVM
            {
                Id = dto.Id,
                InvoiceId = dto.InvoiceId,
                InvoiceNumber = dto.InvoiceNumber,
                PaymentDate = dto.PaymentDate,
                Amount = dto.Amount,
                PaymentMethod = dto.PaymentMethod.ToString(),
                TransactionId = dto.ReferenceNumber,
                Notes = null
            }).ToList();
        }

        public async Task<List<PaymentListVM>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var url = $"api/Payments/date-range?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}";
            var response = await _client.GetFromJsonAsync<ApiResponse<List<PaymentListApiModel>>>(url);
            if (response == null || !response.Success || response.Data == null)
                return new List<PaymentListVM>();

            return response.Data.Select(dto => new PaymentListVM
            {
                Id = dto.Id,
                InvoiceId = dto.InvoiceId,
                InvoiceNumber = dto.InvoiceNumber,
                PaymentDate = dto.PaymentDate,
                Amount = dto.Amount,
                PaymentMethod = dto.PaymentMethod.ToString(),
                TransactionId = dto.ReferenceNumber,
                Notes = null
            }).ToList();
        }

        public async Task<PaymentEditVM?> GetByIdAsync(int id)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<PaymentDetailApiModel>>($"api/Payments/{id}");
            if (response == null || !response.Success || response.Data == null)
                return null;

            // DetailDTO has Notes
            return new PaymentEditVM
            {
                Id = response.Data.Id,
                InvoiceId = response.Data.InvoiceId,
                InvoiceNumber = response.Data.InvoiceNumber,
                CustomerName = response.Data.CustomerName,
                PaymentDate = response.Data.PaymentDate,
                Amount = response.Data.Amount,
                PaymentMethod = response.Data.PaymentMethod.ToString(),
                TransactionId = response.Data.ReferenceNumber,
                Notes = response.Data.Notes
            };
        }

        public async Task<(bool Success, string Message)> CreateAsync(PaymentCreateVM vm)
        {
            // VM → DTO Mapping: string → PaymentMethod enum, TransactionId → ReferenceNumber
            if (!Enum.TryParse<Enums.PaymentMethod>(vm.PaymentMethod, out var method))
                method = Enums.PaymentMethod.Cash;

            var dto = new PaymentCreateApiModel
            {
                InvoiceId = vm.InvoiceId,
                PaymentDate = vm.PaymentDate,
                Amount = vm.Amount,
                PaymentMethod = method,
                ReferenceNumber = vm.TransactionId,
                Notes = vm.Notes
            };

            var response = await _client.PostAsJsonAsync("api/Payments", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<PaymentDetailApiModel>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Ödeme oluşturulamadı");
        }

        public async Task<(bool Success, string Message)> UpdateAsync(PaymentEditVM vm)
        {
            if (!Enum.TryParse<Enums.PaymentMethod>(vm.PaymentMethod, out var method))
                method = Enums.PaymentMethod.Cash;

            var dto = new PaymentUpdateApiModel
            {
                Id = vm.Id,
                PaymentDate = vm.PaymentDate,
                Amount = vm.Amount,
                PaymentMethod = method,
                ReferenceNumber = vm.TransactionId,
                Notes = vm.Notes
            };

            var response = await _client.PutAsJsonAsync($"api/Payments/{vm.Id}", dto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<PaymentDetailApiModel>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Ödeme güncellenemedi");
        }

        public async Task<(bool Success, string Message)> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/Payments/{id}");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            if (result != null && result.Success)
                return (true, result.Message);
            return (false, result?.Message ?? "Ödeme silinemedi");
        }
    }
}

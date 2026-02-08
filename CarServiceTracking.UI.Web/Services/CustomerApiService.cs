using System.Net.Http.Json;
using CarServiceTracking.UI.Web.Models.ApiModels;
using CarServiceTracking.UI.Web.Models.ApiModels.CustomerApiModels;
using CarServiceTracking.UI.Web.ViewModels.Customers;

namespace CarServiceTracking.UI.Web.Services
{
    public class CustomerApiService
    {
        private readonly HttpClient _client;

        public CustomerApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("api");
        }

        public async Task<List<CustomerListVM>> GetAllAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<CustomerListApiModel>>>("api/Customers");

            if (response == null || !response.Success || response.Data == null)
                return new List<CustomerListVM>();

            return response.Data.Select(dto => new CustomerListVM
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                City = dto.City,
                CompanyName = dto.CompanyName,
                CustomerTypeId = dto.CustomerTypeId,
                CustomerTypeName = dto.CustomerTypeName,
                IsActive = dto.IsActive,
                CreatedDate = dto.CreatedDate,
                TotalVehicles = dto.TotalVehicles,
                TotalServices = dto.TotalServices
            }).ToList();
        }

        public async Task<CustomerDetailVM?> GetByIdAsync(int id)
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<CustomerDetailApiModel>>($"api/Customers/{id}");

            if (response == null || !response.Success || response.Data == null)
                return null;

            var dto = response.Data;
            return new CustomerDetailVM
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                City = dto.City,
                Country = dto.Country,
                PostalCode = dto.PostalCode,
                TaxNumber = dto.TaxNumber,
                CompanyName = dto.CompanyName,
                Notes = dto.Notes,
                CustomerTypeId = dto.CustomerTypeId,
                CustomerTypeName = dto.CustomerTypeName,
                IsActive = dto.IsActive,
                CreatedDate = dto.CreatedDate,
                ModifiedDate = dto.ModifiedDate,
                TotalVehicles = dto.TotalVehicles,
                TotalServices = dto.TotalServices,
                CompletedServices = dto.CompletedServices,
                PendingServices = dto.PendingServices
            };
        }

        public async Task<bool> CreateAsync(CustomerCreateVM model)
        {
            try
            {
                var dto = new CustomerCreateApiModel
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone,
                    Address = model.Address,
                    City = model.City,
                    Country = model.Country,
                    PostalCode = model.PostalCode,
                    TaxNumber = model.TaxNumber,
                    CompanyName = model.CompanyName,
                    Notes = model.Notes,
                    CustomerTypeId = model.CustomerTypeId
                };

                var response = await _client.PostAsJsonAsync("api/Customers", dto);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Error: {response.StatusCode} - {errorContent}");
                    return false;
                }

                var result = await response.Content.ReadFromJsonAsync<ApiResponse<CustomerDetailApiModel>>();
                return result?.Success ?? false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in CreateAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(CustomerUpdateVM model)
        {
            try
            {
                var dto = new CustomerUpdateApiModel
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone,
                    Address = model.Address,
                    City = model.City,
                    Country = model.Country,
                    PostalCode = model.PostalCode,
                    TaxNumber = model.TaxNumber,
                    CompanyName = model.CompanyName,
                    Notes = model.Notes,
                    CustomerTypeId = model.CustomerTypeId,
                    IsActive = model.IsActive
                };

                var response = await _client.PutAsJsonAsync($"api/Customers/{model.Id}", dto);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Error: {response.StatusCode} - {errorContent}");
                    return false;
                }

                var result = await response.Content.ReadFromJsonAsync<ApiResponse<CustomerDetailApiModel>>();
                return result?.Success ?? false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in UpdateAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _client.DeleteAsync($"api/Customers/{id}");

                if (!response.IsSuccessStatusCode)
                    return false;

                var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
                return result?.Success ?? false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in DeleteAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Dropdown için tüm müşterileri getir
        /// </summary>
        public async Task<List<CustomerListApiModel>> GetAllCustomersAsync()
        {
            var response = await _client.GetAsync("api/Customers");

            if (!response.IsSuccessStatusCode)
                return new List<CustomerListApiModel>();

            var apiResponse = await response.Content
                .ReadFromJsonAsync<ApiResponse<List<CustomerListApiModel>>>();

            return apiResponse?.Data ?? new List<CustomerListApiModel>();
        }
    }
}

using System.Net.Http.Json;
using CarServiceTracking.UI.Web.Models.ApiModels;

namespace CarServiceTracking.UI.Web.Services
{
    public class AuthApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<AuthLoginResponseApiModel?> LoginAsync(string email, string password)
        {
            var client = _httpClientFactory.CreateClient("api");

            var response = await client.PostAsJsonAsync(
                "api/Auth/login",
                new
                {
                    email,
                    password
                });

            if (!response.IsSuccessStatusCode)
                return null;

            // API ApiResponse<T> wrapper kullanıyor
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponseWrapper<AuthLoginResponseApiModel>>();
            
            if (apiResponse?.Success == true && apiResponse.Data != null)
                return apiResponse.Data;

            return null;
        }

        public async Task<(bool Success, string Message)> SignupAsync(
            string firstName, string lastName, string email, string password, string phone)
        {
            var client = _httpClientFactory.CreateClient("api");

            var response = await client.PostAsJsonAsync("api/Auth/signup", new
            {
                firstName,
                lastName,
                email,
                password,
                phone
            });

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponseWrapper<object>>();

            if (apiResponse?.Success == true)
                return (true, apiResponse.Message);

            return (false, apiResponse?.Message ?? "Kayıt sırasında bir hata oluştu.");
        }
    }

    // API'den gelen wrapper model
    public class ApiResponseWrapper<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; } = "";
    }
}

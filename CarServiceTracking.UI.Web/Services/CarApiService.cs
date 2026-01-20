using System.Net.Http.Json;

namespace CarServiceTracking.UI.Web.Services
{
    public class CarApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<CarListVM>> GetAllCarsAsync()
        {
            var client = _httpClientFactory.CreateClient("api");

            var response = await client.GetFromJsonAsync<ApiResponse<List<CarListVM>>>("api/Cars");

            return response?.Data ?? new List<CarListVM>();
        }
    }

    // API response formatına göre
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }

    // UI'da listelemek için basit model
    public class CarListVM
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; } = "";
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public string BrandModel { get; set; } = "";
        public int Year { get; set; }
        public string? Color { get; set; }
        public int? Mileage { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = "";
        public string? FuelTypeName { get; set; }
        public string? TransmissionTypeName { get; set; }
        public string? CarTypeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

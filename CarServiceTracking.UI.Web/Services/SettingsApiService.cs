using System.Net.Http.Json;
using CarServiceTracking.UI.Web.Models.ApiModels;
using CarServiceTracking.UI.Web.Models.ApiModels.SettingsApiModels;

namespace CarServiceTracking.UI.Web.Services
{
    public class SettingsApiService
    {
        private readonly HttpClient _client;

        public SettingsApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("api");
        }

        public async Task<CompanySettingsApiModel?> GetSettingsAsync()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<CompanySettingsApiModel>>("api/Settings");

            if (response == null || !response.Success || response.Data == null)
                return null;

            return response.Data;
        }

        public async Task<(bool Success, string Message)> UpdateSettingsAsync(CompanySettingsApiModel model)
        {
            try
            {
                var response = await _client.PutAsJsonAsync("api/Settings", model);

                if (!response.IsSuccessStatusCode)
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    return (false, $"API hatası ({(int)response.StatusCode}): {response.ReasonPhrase}. " +
                        (response.StatusCode == System.Net.HttpStatusCode.Unauthorized
                            ? "Oturum süreniz dolmuş olabilir, lütfen yeniden giriş yapın."
                            : errorBody.Length > 200 ? "" : errorBody));
                }

                var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                return result != null && result.Success
                    ? (true, result.Message ?? "Ayarlar kaydedildi.")
                    : (false, result?.Message ?? "Bilinmeyen hata.");
            }
            catch (Exception ex)
            {
                return (false, "Bağlantı hatası: " + ex.Message + (ex.InnerException != null ? " | " + ex.InnerException.Message : ""));
            }
        }
    }
}

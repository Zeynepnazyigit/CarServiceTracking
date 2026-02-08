using System.Text.Json.Serialization;

namespace CarServiceTracking.UI.Web.Models.ApiModels
{
    public class ApiResponse<T>
    {
        [JsonPropertyName("data")]
        public T? Data { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}

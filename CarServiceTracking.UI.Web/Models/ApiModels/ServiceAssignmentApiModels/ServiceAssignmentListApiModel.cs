using System.Text.Json.Serialization;

namespace CarServiceTracking.UI.Web.Models.ApiModels.ServiceAssignmentApiModels
{
    public class ServiceAssignmentListApiModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("serviceRequestId")]
        public int ServiceRequestId { get; set; }

        [JsonPropertyName("mechanicId")]
        public int MechanicId { get; set; }

        [JsonPropertyName("mechanicName")]
        public string MechanicName { get; set; } = "";

        [JsonPropertyName("specialization")]
        public string? Specialization { get; set; }

        [JsonPropertyName("assignedAt")]
        public DateTime AssignedAt { get; set; }

        [JsonPropertyName("startedAt")]
        public DateTime? StartedAt { get; set; }

        [JsonPropertyName("completedAt")]
        public DateTime? CompletedAt { get; set; }

        [JsonPropertyName("estimatedHours")]
        public decimal? EstimatedHours { get; set; }

        [JsonPropertyName("actualHours")]
        public decimal? ActualHours { get; set; }

        [JsonPropertyName("notes")]
        public string? Notes { get; set; }
    }
}

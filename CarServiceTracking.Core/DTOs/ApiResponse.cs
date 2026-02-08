namespace CarServiceTracking.Core.DTOs
{
    /// <summary>
    /// Generic API response wrapper - tüm API endpoint'leri bu formatı kullanacak
    /// </summary>
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new();

        // Parameterless constructor (JSON deserialization için gerekli)
        public ApiResponse()
        {
        }

        // Success response constructor
        public ApiResponse(T data, string message = "Success")
        {
            Success = true;
            Data = data;
            Message = message;
        }

        // Error response constructor
        public ApiResponse(bool success, string message, List<string>? errors = null)
        {
            Success = success;
            Message = message;
            Errors = errors ?? new();
        }

        // Static factory methods
        public static ApiResponse<T> SuccessResponse(T data, string message = "Success")
            => new ApiResponse<T>(data, message);

        public static ApiResponse<T> ErrorResponse(string message, List<string>? errors = null)
            => new ApiResponse<T>(false, message, errors);

        public static ApiResponse<T> ErrorResponse(string message, string error)
            => new ApiResponse<T>(false, message, new List<string> { error });
    }

    /// <summary>
    /// ApiResponse'un veri olmaksızın versiyonu (Delete, Update gibi işlemler için)
    /// </summary>
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new();

        public ApiResponse(bool success, string message, List<string>? errors = null)
        {
            Success = success;
            Message = message;
            Errors = errors ?? new();
        }

        public static ApiResponse SuccessResponse(string message = "Success")
            => new ApiResponse(true, message);

        public static ApiResponse ErrorResponse(string message, List<string>? errors = null)
            => new ApiResponse(false, message, errors);

        public static ApiResponse ErrorResponse(string message, string error)
            => new ApiResponse(false, message, new List<string> { error });
    }
}

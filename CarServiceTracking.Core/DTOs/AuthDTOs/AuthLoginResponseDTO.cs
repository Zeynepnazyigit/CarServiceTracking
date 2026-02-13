namespace CarServiceTracking.Core.DTOs.AuthDTOs
{
    public class AuthLoginResponseDTO
    {
        public string Role { get; set; } = ""; // Admin | Customer
        public int UserId { get; set; }
        public int? CustomerId { get; set; }
        public string Email { get; set; } = "";
    }
}

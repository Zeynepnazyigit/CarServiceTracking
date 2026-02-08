namespace CarServiceTracking.UI.Web.Models.ApiModels
{
    public class AuthLoginResponseApiModel
    {
        public int UserId { get; set; }
        public string Email { get; set; } = "";
        public string Role { get; set; } = ""; // "Admin" | "Customer"
        public string Token { get; set; } = "";
        public DateTime ExpiresAt { get; set; }
    }
}

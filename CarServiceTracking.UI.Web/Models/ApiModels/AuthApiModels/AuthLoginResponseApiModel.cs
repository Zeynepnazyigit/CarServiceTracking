namespace CarServiceTracking.UI.Web.Models.ApiModels.AuthApiModels
{
    public class AuthLoginResponseApiModel
    {
        public string Token { get; set; } = "";
        public string Role { get; set; } = ""; // Admin | Customer
        public int UserId { get; set; }
        public int? CustomerId { get; set; }
        public string Email { get; set; } = "";
    }
}

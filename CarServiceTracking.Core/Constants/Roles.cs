namespace CarServiceTracking.Core.Constants
{
    /// <summary>
    /// Uygulama genelinde kullanılan rol sabitleri.
    /// Clean Code: Magic string'ler yerine constant kullanımı.
    /// </summary>
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
        
        /// <summary>
        /// Admin veya Customer rolü için kullanılır.
        /// </summary>
        public const string AdminOrCustomer = "Admin,Customer";
    }
}

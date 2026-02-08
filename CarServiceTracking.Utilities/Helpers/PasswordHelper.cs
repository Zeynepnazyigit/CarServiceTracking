using System;
using System.Security.Cryptography;
using System.Text;

namespace CarServiceTracking.Utilities.Helpers
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Şifreyi hash'e çevir (bcrypt benzeri)
        /// </summary>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Şifre boş olamaz.");

            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Girilen şifreyi hash'le olunan şifre ile karşılaştır
        /// </summary>
        public static bool VerifyPassword(string password, string hash)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(hash))
                return false;

            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hash);
            }
            catch
            {
                return false;
            }
        }
    }
}

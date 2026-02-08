using System;
using System.Threading.Tasks;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.DTOs.AuthDTOs;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Utilities.Helpers;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Services
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IUserRepository _userRepository;

        public UserAuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// User tarafından giriş yap
        /// </summary>
        public async Task<IDataResult<AuthLoginResponseDTO>> LoginAsync(string email, string password)
        {
            // ✅ Email ve şifre boş mu kontrol et
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return new ErrorDataResult<AuthLoginResponseDTO>("E-posta ve şifre gereklidir.");

            // ✅ Kullanıcı var mı kontrol et
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
                return new ErrorDataResult<AuthLoginResponseDTO>("Hatalı e-posta veya şifre.");

            // ✅ Kullanıcı aktif mi kontrol et
            if (!user.IsActive)
                return new ErrorDataResult<AuthLoginResponseDTO>("Bu hesap devre dışıdır.");

            // ✅ Şifre doğru mu kontrol et
            if (!PasswordHelper.VerifyPassword(password, user.PasswordHash))
                return new ErrorDataResult<AuthLoginResponseDTO>("Hatalı e-posta veya şifre.");

            // ✅ Login başarılı
            var loginResult = new AuthLoginResponseDTO
            {
                UserId = user.Id,
                Email = user.Email,
                Role = user.Role
            };

            return new SuccessDataResult<AuthLoginResponseDTO>(loginResult, "Giriş başarılı.");
        }

        /// <summary>
        /// Email'e göre user'ı getir (token oluşturmak için)
        /// </summary>
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            return await _userRepository.GetUserByEmailAsync(email);
        }
    }
}

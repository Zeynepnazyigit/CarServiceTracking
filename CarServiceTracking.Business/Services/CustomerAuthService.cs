using System.Threading.Tasks;
using AutoMapper;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.DTOs.CustomerDTOs;
using CarServiceTracking.Core.DTOs.AuthDTOs;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Utilities.Results;
using CarServiceTracking.Utilities.Helpers;

namespace CarServiceTracking.Business.Services
{
    public class CustomerAuthService : ICustomerAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerAuthService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // =========================
        // SIGNUP (Customer + User)
        // =========================
        public async Task<IResult> SignupAsync(CustomerSignupDTO dto)
        {
            // E-posta kontrolü
            var customerExists = await _unitOfWork.Customers
                .AnyAsync(c => c.Email == dto.Email);
            if (customerExists)
                return new ErrorResult("Bu e-posta zaten kayıtlı.");

            var userExists = await _unitOfWork.Users
                .AnyAsync(u => u.Email == dto.Email);
            if (userExists)
                return new ErrorResult("Bu e-posta zaten kayıtlı.");

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                // 1. Customer kaydı
                var customer = _mapper.Map<Customer>(dto);
                customer.IsActive = true;
                customer.Password = PasswordHelper.HashPassword(dto.Password);

                await _unitOfWork.Customers.AddAsync(customer);
                await _unitOfWork.SaveChangesAsync();

                // 2. User kaydı (login için gerekli)
                var user = new User
                {
                    Email = dto.Email,
                    PasswordHash = PasswordHelper.HashPassword(dto.Password),
                    Role = "Customer",
                    CustomerId = customer.Id,
                    IsActive = true
                };

                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitAsync();
                return new SuccessResult("Kayıt başarılı! Giriş yapabilirsiniz.");
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                return new ErrorResult("Kayıt sırasında bir hata oluştu.");
            }
        }

        // =========================
        // LOGIN (Admin + Customer)
        // =========================
        public async Task<IDataResult<AuthLoginResponseDTO>> LoginAsync(CustomerLoginDTO dto)
        {
            // 🔒 ADMIN (demo) - backward compatibility
            if (dto.Email == "admin@demo.com" && dto.Password == "12345678!")
            {
                return new SuccessDataResult<AuthLoginResponseDTO>(
                    new AuthLoginResponseDTO
                    {
                        Role = "Admin",
                        UserId = 0,
                        Email = "admin@demo.com"
                    },
                    "Admin girişi başarılı"
                );
            }

            // 👤 USER (DB) - User tablosundan authenticate et
            var user = await _unitOfWork.Users
                .GetAsync(u => u.Email == dto.Email && u.IsActive);

            if (user == null)
                return new ErrorDataResult<AuthLoginResponseDTO>("E-posta veya şifre hatalı.");

            // Şifreyi hash ile kontrol et
            if (!PasswordHelper.VerifyPassword(dto.Password, user.PasswordHash))
                return new ErrorDataResult<AuthLoginResponseDTO>("E-posta veya şifre hatalı.");

            return new SuccessDataResult<AuthLoginResponseDTO>(
                new AuthLoginResponseDTO
                {
                    Role = user.Role, // "Admin" veya "Customer"
                    UserId = user.Id,
                    CustomerId = user.CustomerId,
                    Email = user.Email
                },
                "Giriş başarılı"
            );
        }
    }
}

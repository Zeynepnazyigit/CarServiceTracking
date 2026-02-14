using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.DTOs.SettingsDTOs;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Utilities.Results;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceTracking.Business.Services
{
    public class CompanySettingsService : ICompanySettingsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanySettingsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<CompanySettingsDTO>> GetAsync()
        {
            var list = await _unitOfWork.CompanySettings.GetListAsync(x => !x.IsDeleted);
            var entity = list.FirstOrDefault();

            if (entity == null)
                return new ErrorDataResult<CompanySettingsDTO>("Sistem ayarları bulunamadı.");

            var dto = MapToDto(entity);
            return new SuccessDataResult<CompanySettingsDTO>(dto, "Ayarlar başarıyla getirildi.");
        }

        public async Task<IResult> UpdateAsync(CompanySettingsDTO dto)
        {
            var list = await _unitOfWork.CompanySettings.GetListAsync(x => !x.IsDeleted);
            var entity = list.FirstOrDefault();

            if (entity == null)
            {
                entity = new CompanySettings();
                await _unitOfWork.CompanySettings.AddAsync(entity);
            }
            else
            {
                entity.CompanyName = dto.CompanyName;
                entity.Email = dto.Email;
                entity.Phone = dto.Phone;
                entity.Address = dto.Address;
                entity.DefaultLanguage = dto.DefaultLanguage;
                entity.Currency = dto.Currency;
                entity.DateFormat = dto.DateFormat;
                entity.EmailNotifications = dto.EmailNotifications;
                entity.SmsNotifications = dto.SmsNotifications;
                entity.SessionTimeoutMinutes = dto.SessionTimeoutMinutes;
                entity.MinPasswordLength = dto.MinPasswordLength;
                entity.TwoFactorAuth = dto.TwoFactorAuth;
                await _unitOfWork.CompanySettings.UpdateAsync(entity);
            }

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Ayarlar başarıyla güncellendi.");
        }

        private static CompanySettingsDTO MapToDto(CompanySettings entity)
        {
            return new CompanySettingsDTO
            {
                Id = entity.Id,
                CompanyName = entity.CompanyName,
                Email = entity.Email,
                Phone = entity.Phone,
                Address = entity.Address,
                DefaultLanguage = entity.DefaultLanguage,
                Currency = entity.Currency,
                DateFormat = entity.DateFormat,
                EmailNotifications = entity.EmailNotifications,
                SmsNotifications = entity.SmsNotifications,
                SessionTimeoutMinutes = entity.SessionTimeoutMinutes,
                MinPasswordLength = entity.MinPasswordLength,
                TwoFactorAuth = entity.TwoFactorAuth
            };
        }
    }
}

using CarServiceTracking.Core.DTOs.SettingsDTOs;
using CarServiceTracking.Utilities.Results;
using System.Threading.Tasks;

namespace CarServiceTracking.Business.Abstract
{
    public interface ICompanySettingsService
    {
        Task<IDataResult<CompanySettingsDTO>> GetAsync();
        Task<IResult> UpdateAsync(CompanySettingsDTO dto);
    }
}

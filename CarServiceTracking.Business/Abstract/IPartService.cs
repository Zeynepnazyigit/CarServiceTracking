using CarServiceTracking.Core.DTOs.PartDTOs;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Abstract
{
    public interface IPartService
    {
        Task<IDataResult<List<PartListDTO>>> GetAllAsync();
        Task<IDataResult<List<PartListDTO>>> GetLowStockPartsAsync();
        Task<IDataResult<List<PartListDTO>>> GetByCategoryAsync(string category);
        Task<IDataResult<PartDetailDTO>> GetByIdAsync(int id);
        Task<IDataResult<PartDetailDTO>> GetByPartCodeAsync(string partCode);
        Task<IDataResult<PartDetailDTO>> CreateAsync(PartCreateDTO dto);
        Task<IDataResult<PartDetailDTO>> UpdateAsync(PartUpdateDTO dto);
        Task<IResult> DeleteAsync(int id);
        Task<IResult> UpdateStockAsync(int partId, int quantity);
    }
}

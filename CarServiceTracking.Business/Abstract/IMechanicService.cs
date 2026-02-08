using CarServiceTracking.Core.DTOs.MechanicDTOs;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Abstract
{
    public interface IMechanicService
    {
        Task<IDataResult<List<MechanicListDTO>>> GetAllAsync();
        Task<IDataResult<List<MechanicListDTO>>> GetAvailableMechanicsAsync();
        Task<IDataResult<List<MechanicListDTO>>> GetBySpecializationAsync(string specialization);
        Task<IDataResult<MechanicDetailDTO>> GetByIdAsync(int id);
        Task<IDataResult<MechanicDetailDTO>> CreateAsync(MechanicCreateDTO dto);
        Task<IDataResult<MechanicDetailDTO>> UpdateAsync(MechanicUpdateDTO dto);
        Task<IResult> DeleteAsync(int id);
    }
}

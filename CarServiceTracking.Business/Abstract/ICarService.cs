using CarServiceTracking.Core.DTOs.CarDTOs;
using CarServiceTracking.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceTracking.Business.Abstract
{
    public interface ICarService
    {
        Task<IDataResult<List<CarListDTO>>> GetAllAsync();
        Task<IDataResult<List<CarListDTO>>> GetActiveAsync();
        Task<IDataResult<List<CarListItemDTO>>> GetCarListItemsAsync();
        Task<IDataResult<List<CarListDTO>>> GetCarsByCustomerIdAsync(int customerId);
        Task<IDataResult<List<CarListDTO>>> SearchCarsAsync(string searchTerm);
        Task<IDataResult<CarDetailDTO>> GetByIdAsync(int id);
        Task<IDataResult<CarDetailDTO>> GetByPlateNumberAsync(string plateNumber);
        Task<IDataResult<CarDetailDTO>> CreateAsync(CarCreateDTO dto);
        Task<IDataResult<CarDetailDTO>> UpdateAsync(CarUpdateDTO dto);
        Task<IResult> SoftDeleteAsync(int id);
        Task<IResult> SetActiveAsync(int id, bool isActive);
    }
}

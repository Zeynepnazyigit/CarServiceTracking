using CarServiceTracking.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceTracking.Core.Abstracts
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllWithDetailsAsync();
        Task<Car?> GetByIdWithDetailsAsync(int id);
        Task<Car?> GetByPlateNumberWithDetailsAsync(string plateNumber);
        Task<IEnumerable<Car>> GetCarsByCustomerIdWithDetailsAsync(int customerId);
        Task<bool> IsPlateExistsAsync(string plateNumber, int? excludeId = null);
    }
}
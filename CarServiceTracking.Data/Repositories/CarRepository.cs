using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceTracking.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllWithDetailsAsync()
        {
            return await _context.Cars
                .Include(c => c.Customer)
                .Include(c => c.FuelTypeItem)
                .Include(c => c.TransmissionTypeItem)
                .Include(c => c.CarTypeItem)
                .ToListAsync();
        }

        public async Task<Car?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Cars
                .Include(c => c.Customer)
                .Include(c => c.FuelTypeItem)
                .Include(c => c.TransmissionTypeItem)
                .Include(c => c.CarTypeItem)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Car?> GetByPlateNumberWithDetailsAsync(string plateNumber)
        {
            return await _context.Cars
                .Include(c => c.Customer)
                .Include(c => c.FuelTypeItem)
                .Include(c => c.TransmissionTypeItem)
                .Include(c => c.CarTypeItem)
                .FirstOrDefaultAsync(c => c.PlateNumber == plateNumber);
        }

        public async Task<IEnumerable<Car>> GetCarsByCustomerIdWithDetailsAsync(int customerId)
        {
            return await _context.Cars
                .Include(c => c.Customer)
                .Include(c => c.FuelTypeItem)
                .Include(c => c.TransmissionTypeItem)
                .Include(c => c.CarTypeItem)
                .Where(c => c.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<bool> IsPlateExistsAsync(string plateNumber, int? excludeId = null)
        {
            if (excludeId.HasValue)
                return await _context.Cars.AnyAsync(c => c.PlateNumber == plateNumber && c.Id != excludeId.Value);

            return await _context.Cars.AnyAsync(c => c.PlateNumber == plateNumber);
        }
    }
}
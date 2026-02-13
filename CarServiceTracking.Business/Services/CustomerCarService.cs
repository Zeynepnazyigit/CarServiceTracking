using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.Entities;

namespace CarServiceTracking.Business.Services
{
    public class CustomerCarService : ICustomerCarService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerCarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // =========================
        // Tüm araçlar (Admin)
        // =========================
        public async Task<List<CustomerCar>> GetAllAsync()
        {
            var allCars = await _unitOfWork.CustomerCars.GetAllAsync();
            return allCars.Where(x => !x.IsDeleted && x.IsActive).ToList();
        }

        // =========================
        // Customer'a ait araçlar
        // =========================
        public async Task<List<CustomerCar>> GetByCustomerIdAsync(int customerId)
        {
            var allCars = await _unitOfWork.CustomerCars.GetAllAsync();

            return allCars
                .Where(x =>
                    x.CustomerId == customerId &&
                    !x.IsDeleted &&
                    x.IsActive
                )
                .ToList();
        }

        // =========================
        // Tek araç
        // =========================
        public async Task<CustomerCar?> GetByIdAsync(int id)
        {
            return await _unitOfWork.CustomerCars
                .GetAsync(x => x.Id == id && !x.IsDeleted);
        }

        // =========================
        // Yeni araç ekleme
        // =========================
        public async Task<CustomerCar> AddAsync(CustomerCar customerCar)
        {
            // 🔥 KRİTİK SATIRLAR
            customerCar.IsDeleted = false;
            customerCar.IsActive = true;
            customerCar.CreatedDate = DateTime.Now;

            await _unitOfWork.CustomerCars.AddAsync(customerCar);
            await _unitOfWork.SaveChangesAsync();

            return customerCar;
        }
    }
}

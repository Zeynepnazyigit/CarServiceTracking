using CarServiceTracking.Core.Entities;

namespace CarServiceTracking.Business.Abstract
{
    public interface ICustomerCarService
    {
        /// <summary>
        /// Müşteriye ait şahsi araçları getirir
        /// </summary>
        Task<List<CustomerCar>> GetByCustomerIdAsync(int customerId);

        /// <summary>
        /// Id ile şahsi araç getirir
        /// </summary>
        Task<CustomerCar?> GetByIdAsync(int id);

        /// <summary>
        /// Yeni şahsi araç ekler
        /// </summary>
        Task<CustomerCar> AddAsync(CustomerCar customerCar);
    }
}

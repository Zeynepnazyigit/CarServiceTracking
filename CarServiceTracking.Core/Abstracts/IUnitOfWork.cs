using CarServiceTracking.Core.Entities;
using System;
using System.Threading.Tasks;

namespace CarServiceTracking.Core.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> Customers { get; }
        IRepository<Car> Cars { get; }
        ICarRepository CarRepository { get; }

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
using CarServiceTracking.Core;
using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Data.Contexts;
using CarServiceTracking.Data.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace CarServiceTracking.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;

        private IRepository<Customer>? _customers;
        private IRepository<Car>? _cars;
        private ICarRepository? _carRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<Customer> Customers => _customers ??= new Repository<Customer>(_context);
        public IRepository<Car> Cars => _cars ??= new Repository<Car>(_context);
        public ICarRepository CarRepository => _carRepository ??= new CarRepository(_context);

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
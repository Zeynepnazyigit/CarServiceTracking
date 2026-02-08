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

        // Core Entities - Lazy Loading
        private IRepository<Customer>? _customers;
        private IRepository<Car>? _cars;
        private IRepository<ServiceRequest>? _serviceRequests;
        private IRepository<ServiceRecord>? _serviceRecords;
        private IRepository<CustomerCar>? _customerCars;
        private IRepository<User>? _users;
        
        // New Module Entities - Lazy Loading
        private IRepository<ListItem>? _listItems;
        private IRepository<Part>? _parts;
        private IRepository<ServicePart>? _serviceParts;
        private IRepository<Invoice>? _invoices;
        private IRepository<Payment>? _payments;
        private IRepository<Appointment>? _appointments;
        private IRepository<Mechanic>? _mechanics;
        private IRepository<ServiceAssignment>? _serviceAssignments;
        private IRepository<RentalVehicle>? _rentalVehicles;
        private IRepository<RentalAgreement>? _rentalAgreements;

        // Specialized Repositories
        private ICarRepository? _carRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Core Entities - Properties
        public IRepository<Customer> Customers
            => _customers ??= new Repository<Customer>(_context);

        public IRepository<Car> Cars
            => _cars ??= new Repository<Car>(_context);

        public IRepository<ServiceRequest> ServiceRequests
            => _serviceRequests ??= new Repository<ServiceRequest>(_context);

        public IRepository<ServiceRecord> ServiceRecords
            => _serviceRecords ??= new Repository<ServiceRecord>(_context);

        public IRepository<CustomerCar> CustomerCars
            => _customerCars ??= new Repository<CustomerCar>(_context);

        public IRepository<User> Users
            => _users ??= new Repository<User>(_context);

        // New Module Entities - Properties
        public IRepository<ListItem> ListItems
            => _listItems ??= new Repository<ListItem>(_context);

        public IRepository<Part> Parts
            => _parts ??= new Repository<Part>(_context);

        public IRepository<ServicePart> ServiceParts
            => _serviceParts ??= new Repository<ServicePart>(_context);

        public IRepository<Invoice> Invoices
            => _invoices ??= new Repository<Invoice>(_context);

        public IRepository<Payment> Payments
            => _payments ??= new Repository<Payment>(_context);

        public IRepository<Appointment> Appointments
            => _appointments ??= new Repository<Appointment>(_context);

        public IRepository<Mechanic> Mechanics
            => _mechanics ??= new Repository<Mechanic>(_context);

        public IRepository<ServiceAssignment> ServiceAssignments
            => _serviceAssignments ??= new Repository<ServiceAssignment>(_context);

        public IRepository<RentalVehicle> RentalVehicles
            => _rentalVehicles ??= new Repository<RentalVehicle>(_context);

        public IRepository<RentalAgreement> RentalAgreements
            => _rentalAgreements ??= new Repository<RentalAgreement>(_context);

        // Specialized Repositories
        public ICarRepository CarRepository
            => _carRepository ??= new CarRepository(_context);

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
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

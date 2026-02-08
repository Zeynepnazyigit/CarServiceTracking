using CarServiceTracking.Core.Entities;
using System;
using System.Threading.Tasks;

namespace CarServiceTracking.Core.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        // Core Entities
        IRepository<Customer> Customers { get; }
        IRepository<Car> Cars { get; }
        IRepository<ServiceRequest> ServiceRequests { get; }
        IRepository<ServiceRecord> ServiceRecords { get; }
        IRepository<CustomerCar> CustomerCars { get; }
        IRepository<User> Users { get; }
        
        // New Module Entities
        IRepository<ListItem> ListItems { get; }
        IRepository<Part> Parts { get; }
        IRepository<ServicePart> ServiceParts { get; }
        IRepository<Invoice> Invoices { get; }
        IRepository<Payment> Payments { get; }
        IRepository<Appointment> Appointments { get; }
        IRepository<Mechanic> Mechanics { get; }
        IRepository<ServiceAssignment> ServiceAssignments { get; }
        IRepository<RentalVehicle> RentalVehicles { get; }
        IRepository<RentalAgreement> RentalAgreements { get; }
        
        // Specialized Repositories
        ICarRepository CarRepository { get; }

        // Transaction Management
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}

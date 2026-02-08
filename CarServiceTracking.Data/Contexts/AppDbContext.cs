using CarServiceTracking.Core.Entities;
using CarServiceTracking.Data.Seed;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CarServiceTracking.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets (Tablolar)
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<ServiceRecord> ServiceRecords { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<CustomerCar> CustomerCars { get; set; }
        
        // Yeni Modüller
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ServicePart> ServiceParts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<ServiceAssignment> ServiceAssignments { get; set; }
        public DbSet<RentalVehicle> RentalVehicles { get; set; }
        public DbSet<RentalAgreement> RentalAgreements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - Customer relationship (1-1 optional)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Customer)
                .WithOne(c => c.User)
                .HasForeignKey<User>(u => u.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            // ServiceRequest - ServicePrice decimal precision
            modelBuilder.Entity<ServiceRequest>()
                .Property(x => x.ServicePrice)
                .HasPrecision(18, 2);

            // ServiceRequest -> Car relation
            modelBuilder.Entity<ServiceRequest>()
                .HasOne(x => x.Car)
                .WithMany()
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            // Apply all configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Seed initial data
            SeedData.Initialize(modelBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarServiceTracking.API.Temp;

public partial class CarServiceTrackingDbContext : DbContext
{
    public CarServiceTrackingDbContext()
    {
    }

    public CarServiceTrackingDbContext(DbContextOptions<CarServiceTrackingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerCar> CustomerCars { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<ListItem> ListItems { get; set; }

    public virtual DbSet<Mechanic> Mechanics { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<RentalAgreement> RentalAgreements { get; set; }

    public virtual DbSet<RentalVehicle> RentalVehicles { get; set; }

    public virtual DbSet<ServiceAssignment> ServiceAssignments { get; set; }

    public virtual DbSet<ServicePart> ServiceParts { get; set; }

    public virtual DbSet<ServiceRecord> ServiceRecords { get; set; }

    public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasIndex(e => e.AppointmentDate, "IX_Appointments_AppointmentDate");

            entity.HasIndex(e => e.CarId, "IX_Appointments_CarId");

            entity.HasIndex(e => e.CustomerId, "IX_Appointments_CustomerId");

            entity.HasIndex(e => e.IsDeleted, "IX_Appointments_IsDeleted");

            entity.HasIndex(e => e.Status, "IX_Appointments_Status");

            entity.Property(e => e.AdminNotes).HasMaxLength(500);
            entity.Property(e => e.CancellationReason).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CustomerNotes).HasMaxLength(500);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ServiceType).HasMaxLength(100);
            entity.Property(e => e.TimeSlot).HasMaxLength(20);

            entity.HasOne(d => d.Car).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Customer).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasIndex(e => e.CarTypeId, "IX_Cars_CarTypeId");

            entity.HasIndex(e => e.CustomerId, "IX_Cars_CustomerId");

            entity.HasIndex(e => e.FuelTypeId, "IX_Cars_FuelTypeId");

            entity.HasIndex(e => e.IsActive, "IX_Cars_IsActive");

            entity.HasIndex(e => e.IsDeleted, "IX_Cars_IsDeleted");

            entity.HasIndex(e => e.PlateNumber, "IX_Cars_PlateNumber").IsUnique();

            entity.HasIndex(e => e.TransmissionTypeId, "IX_Cars_TransmissionTypeId");

            entity.Property(e => e.Brand).HasMaxLength(100);
            entity.Property(e => e.ChassisNumber).HasMaxLength(50);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EngineNumber).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(1000);
            entity.Property(e => e.PlateNumber).HasMaxLength(20);

            entity.HasOne(d => d.CarType).WithMany(p => p.CarCarTypes).HasForeignKey(d => d.CarTypeId);

            entity.HasOne(d => d.Customer).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.FuelType).WithMany(p => p.CarFuelTypes).HasForeignKey(d => d.FuelTypeId);

            entity.HasOne(d => d.TransmissionType).WithMany(p => p.CarTransmissionTypes).HasForeignKey(d => d.TransmissionTypeId);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasIndex(e => e.CustomerTypeId, "IX_Customers_CustomerTypeId");

            entity.HasIndex(e => e.Email, "IX_Customers_Email").IsUnique();

            entity.HasIndex(e => e.IsActive, "IX_Customers_IsActive");

            entity.HasIndex(e => e.IsDeleted, "IX_Customers_IsDeleted");

            entity.HasIndex(e => e.Phone, "IX_Customers_Phone");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CompanyName).HasMaxLength(200);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(1000);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PostalCode).HasMaxLength(20);
            entity.Property(e => e.TaxNumber).HasMaxLength(50);

            entity.HasOne(d => d.CustomerType).WithMany(p => p.Customers).HasForeignKey(d => d.CustomerTypeId);
        });

        modelBuilder.Entity<CustomerCar>(entity =>
        {
            entity.HasIndex(e => e.CarId, "IX_CustomerCars_CarId");

            entity.HasIndex(e => e.CustomerId, "IX_CustomerCars_CustomerId");

            entity.HasOne(d => d.Car).WithMany(p => p.CustomerCars).HasForeignKey(d => d.CarId);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerCars).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_Invoices_CustomerId");

            entity.HasIndex(e => e.InvoiceNumber, "IX_Invoices_InvoiceNumber").IsUnique();

            entity.HasIndex(e => e.IsDeleted, "IX_Invoices_IsDeleted");

            entity.HasIndex(e => e.PaymentStatus, "IX_Invoices_PaymentStatus");

            entity.HasIndex(e => e.ServiceRequestId, "IX_Invoices_ServiceRequestId").IsUnique();

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.GrandTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(50);
            entity.Property(e => e.LaborCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Notes).HasMaxLength(1000);
            entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PartsTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RemainingAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxRate)
                .HasDefaultValue(200m)
                .HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ServiceRequest).WithOne(p => p.Invoice)
                .HasForeignKey<Invoice>(d => d.ServiceRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ListItem>(entity =>
        {
            entity.HasIndex(e => e.IsDeleted, "IX_ListItems_IsDeleted");

            entity.HasIndex(e => e.ListType, "IX_ListItems_ListType");

            entity.HasIndex(e => new { e.ListType, e.SortOrder }, "IX_ListItems_ListType_SortOrder");

            entity.HasIndex(e => e.ParentId, "IX_ListItems_ParentId");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ListType).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent).HasForeignKey(d => d.ParentId);
        });

        modelBuilder.Entity<Mechanic>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Mechanics_Email").IsUnique();

            entity.HasIndex(e => e.IsDeleted, "IX_Mechanics_IsDeleted");

            entity.HasIndex(e => e.Phone, "IX_Mechanics_Phone");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.HireDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.HourlyRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(1000);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Specialization).HasMaxLength(200);
        });

        modelBuilder.Entity<Part>(entity =>
        {
            entity.HasIndex(e => e.Category, "IX_Parts_Category");

            entity.HasIndex(e => e.IsDeleted, "IX_Parts_IsDeleted");

            entity.HasIndex(e => e.PartCode, "IX_Parts_PartCode").IsUnique();

            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MinStockLevel).HasDefaultValue(5);
            entity.Property(e => e.PartCode).HasMaxLength(50);
            entity.Property(e => e.PartName).HasMaxLength(200);
            entity.Property(e => e.Supplier).HasMaxLength(200);
            entity.Property(e => e.SupplierContact).HasMaxLength(200);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasIndex(e => e.InvoiceId, "IX_Payments_InvoiceId");

            entity.HasIndex(e => e.IsDeleted, "IX_Payments_IsDeleted");

            entity.HasIndex(e => e.PaymentDate, "IX_Payments_PaymentDate");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Reference).HasMaxLength(200);
            entity.Property(e => e.TransactionId).HasMaxLength(100);

            entity.HasOne(d => d.Invoice).WithMany(p => p.Payments)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RentalAgreement>(entity =>
        {
            entity.HasIndex(e => e.AgreementNumber, "IX_RentalAgreements_AgreementNumber").IsUnique();

            entity.HasIndex(e => e.CustomerId, "IX_RentalAgreements_CustomerId");

            entity.HasIndex(e => e.IsDeleted, "IX_RentalAgreements_IsDeleted");

            entity.HasIndex(e => e.RentalVehicleId, "IX_RentalAgreements_RentalVehicleId");

            entity.HasIndex(e => e.ServiceRequestId, "IX_RentalAgreements_ServiceRequestId")
                .IsUnique()
                .HasFilter("([ServiceRequestId] IS NOT NULL)");

            entity.HasIndex(e => e.Status, "IX_RentalAgreements_Status");

            entity.Property(e => e.AgreementNumber).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DailyRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DamageNotes).HasMaxLength(1000);
            entity.Property(e => e.DepositAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LateFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PickupNotes).HasMaxLength(1000);
            entity.Property(e => e.ReturnNotes).HasMaxLength(1000);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.RentalAgreements)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.RentalVehicle).WithMany(p => p.RentalAgreements)
                .HasForeignKey(d => d.RentalVehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ServiceRequest).WithOne(p => p.RentalAgreement)
                .HasForeignKey<RentalAgreement>(d => d.ServiceRequestId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<RentalVehicle>(entity =>
        {
            entity.HasIndex(e => e.IsAvailable, "IX_RentalVehicles_IsAvailable");

            entity.HasIndex(e => e.IsDeleted, "IX_RentalVehicles_IsDeleted");

            entity.HasIndex(e => e.PlateNumber, "IX_RentalVehicles_PlateNumber").IsUnique();

            entity.Property(e => e.Brand).HasMaxLength(100);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DailyRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FuelType).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(1000);
            entity.Property(e => e.PlateNumber).HasMaxLength(20);
            entity.Property(e => e.TransmissionType).HasMaxLength(50);
            entity.Property(e => e.VehicleCondition).HasMaxLength(500);
        });

        modelBuilder.Entity<ServiceAssignment>(entity =>
        {
            entity.HasIndex(e => e.IsDeleted, "IX_ServiceAssignments_IsDeleted");

            entity.HasIndex(e => e.MechanicId, "IX_ServiceAssignments_MechanicId");

            entity.HasIndex(e => e.ServiceRequestId, "IX_ServiceAssignments_ServiceRequestId");

            entity.Property(e => e.ActualHours).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.AssignedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EstimatedHours).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Notes).HasMaxLength(1000);

            entity.HasOne(d => d.Mechanic).WithMany(p => p.ServiceAssignments)
                .HasForeignKey(d => d.MechanicId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ServiceRequest).WithMany(p => p.ServiceAssignments)
                .HasForeignKey(d => d.ServiceRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ServicePart>(entity =>
        {
            entity.HasIndex(e => e.IsDeleted, "IX_ServiceParts_IsDeleted");

            entity.HasIndex(e => e.PartId, "IX_ServiceParts_PartId");

            entity.HasIndex(e => e.ServiceRequestId, "IX_ServiceParts_ServiceRequestId");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Part).WithMany(p => p.ServiceParts)
                .HasForeignKey(d => d.PartId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ServiceRequest).WithMany(p => p.ServiceParts)
                .HasForeignKey(d => d.ServiceRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ServiceRecord>(entity =>
        {
            entity.HasIndex(e => e.CarId, "IX_ServiceRecords_CarId");

            entity.HasIndex(e => e.CustomerId, "IX_ServiceRecords_CustomerId");

            entity.HasIndex(e => e.IsActive, "IX_ServiceRecords_IsActive");

            entity.HasIndex(e => e.IsDeleted, "IX_ServiceRecords_IsDeleted");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Car).WithMany(p => p.ServiceRecords)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Customer).WithMany(p => p.ServiceRecords)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ServiceRequest>(entity =>
        {
            entity.HasIndex(e => e.CarId, "IX_ServiceRequests_CarId");

            entity.HasIndex(e => e.CustomerId, "IX_ServiceRequests_CustomerId");

            entity.HasIndex(e => e.IsActive, "IX_ServiceRequests_IsActive");

            entity.HasIndex(e => e.IsDeleted, "IX_ServiceRequests_IsDeleted");

            entity.HasIndex(e => e.Status, "IX_ServiceRequests_Status");

            entity.Property(e => e.ServicePrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Car).WithMany(p => p.ServiceRequests)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Customer).WithMany(p => p.ServiceRequests)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_Users_CustomerId")
                .IsUnique()
                .HasFilter("([CustomerId] IS NOT NULL)");

            entity.HasOne(d => d.Customer).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

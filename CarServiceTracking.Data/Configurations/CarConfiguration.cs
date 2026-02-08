using CarServiceTracking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarServiceTracking.Data.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");

            // Primary Key
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(c => c.PlateNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Brand)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Model)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Year)
                .IsRequired();

            builder.Property(c => c.Color)
                .HasMaxLength(50);

            builder.Property(c => c.ChassisNumber)
                .HasMaxLength(50);

            builder.Property(c => c.EngineNumber)
                .HasMaxLength(50);

            builder.Property(c => c.Notes)
                .HasMaxLength(1000);

            // Indexes
            builder.HasIndex(c => c.PlateNumber)
                .IsUnique();

            builder.HasIndex(c => c.CustomerId);

            builder.HasIndex(c => c.IsDeleted);

            builder.HasIndex(c => c.IsActive);

            // Relationships
            builder.HasOne(c => c.Customer)
                .WithMany(cu => cu.Cars)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.FuelTypeItem)
                .WithMany()
                .HasForeignKey(c => c.FuelTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.TransmissionTypeItem)
                .WithMany()
                .HasForeignKey(c => c.TransmissionTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.CarTypeItem)
                .WithMany()
                .HasForeignKey(c => c.CarTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(c => !c.IsDeleted);

            // Default Values
            builder.Property(c => c.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(c => c.IsActive)
                .HasDefaultValue(true);

            builder.Property(c => c.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
using CarServiceTracking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarServiceTracking.Data.Configurations
{
    public class RentalVehicleConfiguration : IEntityTypeConfiguration<RentalVehicle>
    {
        public void Configure(EntityTypeBuilder<RentalVehicle> builder)
        {
            builder.ToTable("RentalVehicles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PlateNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Brand)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Model)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Year)
                .IsRequired();

            builder.Property(x => x.Color)
                .HasMaxLength(50);

            builder.Property(x => x.FuelType)
                .HasMaxLength(50);

            builder.Property(x => x.TransmissionType)
                .HasMaxLength(50);

            builder.Property(x => x.Mileage)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.DailyRate)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(x => x.IsAvailable)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.VehicleCondition)
                .HasMaxLength(500);

            builder.Property(x => x.Notes)
                .HasMaxLength(1000);

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Indexes
            builder.HasIndex(x => x.PlateNumber)
                .IsUnique()
                .HasDatabaseName("IX_RentalVehicles_PlateNumber");

            builder.HasIndex(x => x.IsAvailable)
                .HasDatabaseName("IX_RentalVehicles_IsAvailable");

            builder.HasIndex(x => x.IsDeleted)
                .HasDatabaseName("IX_RentalVehicles_IsDeleted");

            // Query Filter
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}

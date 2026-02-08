using CarServiceTracking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarServiceTracking.Data.Configurations
{
    public class RentalAgreementConfiguration : IEntityTypeConfiguration<RentalAgreement>
    {
        public void Configure(EntityTypeBuilder<RentalAgreement> builder)
        {
            builder.ToTable("RentalAgreements");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AgreementNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.StartDate)
                .IsRequired();

            builder.Property(x => x.EndDate)
                .IsRequired();

            builder.Property(x => x.DailyRate)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(x => x.TotalDays)
                .IsRequired();

            builder.Property(x => x.TotalAmount)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(x => x.DepositAmount)
                .IsRequired()
                .HasPrecision(18, 2)
                .HasDefaultValue(0);

            builder.Property(x => x.LateFee)
                .HasPrecision(18, 2);

            builder.Property(x => x.StartMileage)
                .IsRequired();

            builder.Property(x => x.PickupNotes)
                .HasMaxLength(1000);

            builder.Property(x => x.ReturnNotes)
                .HasMaxLength(1000);

            builder.Property(x => x.DamageNotes)
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

            // Relationships
            builder.HasOne(x => x.Customer)
                .WithMany(x => x.RentalAgreements)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.RentalVehicle)
                .WithMany(x => x.RentalAgreements)
                .HasForeignKey(x => x.RentalVehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ServiceRequest)
                .WithOne(x => x.RentalAgreement)
                .HasForeignKey<RentalAgreement>(x => x.ServiceRequestId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            builder.HasIndex(x => x.AgreementNumber)
                .IsUnique()
                .HasDatabaseName("IX_RentalAgreements_AgreementNumber");

            builder.HasIndex(x => x.CustomerId)
                .HasDatabaseName("IX_RentalAgreements_CustomerId");

            builder.HasIndex(x => x.RentalVehicleId)
                .HasDatabaseName("IX_RentalAgreements_RentalVehicleId");

            builder.HasIndex(x => x.ServiceRequestId)
                .HasDatabaseName("IX_RentalAgreements_ServiceRequestId");

            builder.HasIndex(x => x.Status)
                .HasDatabaseName("IX_RentalAgreements_Status");

            builder.HasIndex(x => x.IsDeleted)
                .HasDatabaseName("IX_RentalAgreements_IsDeleted");

            // Query Filter
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}

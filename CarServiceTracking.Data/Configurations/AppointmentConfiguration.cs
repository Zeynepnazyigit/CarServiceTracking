using CarServiceTracking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarServiceTracking.Data.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AppointmentDate)
                .IsRequired();

            builder.Property(x => x.TimeSlot)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.ServiceType)
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.CustomerNotes)
                .HasMaxLength(500);

            builder.Property(x => x.AdminNotes)
                .HasMaxLength(500);

            builder.Property(x => x.CancellationReason)
                .HasMaxLength(500);

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
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Car)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(x => x.CustomerId)
                .HasDatabaseName("IX_Appointments_CustomerId");

            builder.HasIndex(x => x.CarId)
                .HasDatabaseName("IX_Appointments_CarId");

            builder.HasIndex(x => x.AppointmentDate)
                .HasDatabaseName("IX_Appointments_AppointmentDate");

            builder.HasIndex(x => x.Status)
                .HasDatabaseName("IX_Appointments_Status");

            builder.HasIndex(x => x.IsDeleted)
                .HasDatabaseName("IX_Appointments_IsDeleted");

            // Query Filter
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}

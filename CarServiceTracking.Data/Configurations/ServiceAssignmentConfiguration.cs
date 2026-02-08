using CarServiceTracking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarServiceTracking.Data.Configurations
{
    public class ServiceAssignmentConfiguration : IEntityTypeConfiguration<ServiceAssignment>
    {
        public void Configure(EntityTypeBuilder<ServiceAssignment> builder)
        {
            builder.ToTable("ServiceAssignments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AssignedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.EstimatedHours)
                .HasPrecision(5, 2);

            builder.Property(x => x.ActualHours)
                .HasPrecision(5, 2);

            builder.Property(x => x.Notes)
                .HasMaxLength(1000);

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(x => x.ServiceRequest)
                .WithMany(x => x.ServiceAssignments)
                .HasForeignKey(x => x.ServiceRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Mechanic)
                .WithMany(x => x.ServiceAssignments)
                .HasForeignKey(x => x.MechanicId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(x => x.ServiceRequestId)
                .HasDatabaseName("IX_ServiceAssignments_ServiceRequestId");

            builder.HasIndex(x => x.MechanicId)
                .HasDatabaseName("IX_ServiceAssignments_MechanicId");

            builder.HasIndex(x => x.IsDeleted)
                .HasDatabaseName("IX_ServiceAssignments_IsDeleted");

            // Query Filter
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}

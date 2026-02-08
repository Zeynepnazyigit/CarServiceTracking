using CarServiceTracking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarServiceTracking.Data.Configurations
{
    public class ServicePartConfiguration : IEntityTypeConfiguration<ServicePart>
    {
        public void Configure(EntityTypeBuilder<ServicePart> builder)
        {
            builder.ToTable("ServiceParts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(x => x.TotalPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(x => x.Notes)
                .HasMaxLength(500);

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(x => x.ServiceRequest)
                .WithMany(x => x.ServiceParts)
                .HasForeignKey(x => x.ServiceRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Part)
                .WithMany(x => x.ServiceParts)
                .HasForeignKey(x => x.PartId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(x => x.ServiceRequestId)
                .HasDatabaseName("IX_ServiceParts_ServiceRequestId");

            builder.HasIndex(x => x.PartId)
                .HasDatabaseName("IX_ServiceParts_PartId");

            builder.HasIndex(x => x.IsDeleted)
                .HasDatabaseName("IX_ServiceParts_IsDeleted");

            // Query Filter
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}

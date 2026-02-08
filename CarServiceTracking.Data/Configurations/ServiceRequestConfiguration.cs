using CarServiceTracking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarServiceTracking.Data.Configurations
{
    public class ServiceRequestConfiguration : IEntityTypeConfiguration<ServiceRequest>
    {
        public void Configure(EntityTypeBuilder<ServiceRequest> builder)
        {
            builder.ToTable("ServiceRequests");

            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.ProblemDescription)
                .IsRequired();

            builder.Property(x => x.ServicePrice)
                .HasPrecision(18, 2);

            builder.Property(x => x.Status)
                .IsRequired();

            // Indexes
            builder.HasIndex(x => x.CarId);
            builder.HasIndex(x => x.CustomerId);
            builder.HasIndex(x => x.Status);
            builder.HasIndex(x => x.IsDeleted);
            builder.HasIndex(x => x.IsActive);

            // Relationships
            builder.HasOne(x => x.Car)
                .WithMany(c => c.ServiceRequests)
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Customer)
                .WithMany(c => c.ServiceRequests)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Soft Delete Filter - BU ÇÖZÜM!
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}

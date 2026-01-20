using CarServiceTracking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarServiceTracking.Data.Configurations
{
    public class ServiceRecordConfiguration : IEntityTypeConfiguration<ServiceRecord>
    {
        public void Configure(EntityTypeBuilder<ServiceRecord> builder)
        {
            builder.ToTable("ServiceRecords");

            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .HasMaxLength(2000);

            builder.Property(x => x.ServiceDate)
                .IsRequired();

            builder.Property(x => x.TotalPrice)
                .HasColumnType("decimal(18,2)");

            // Indexes
            builder.HasIndex(x => x.CarId);
            builder.HasIndex(x => x.CustomerId);
            builder.HasIndex(x => x.IsDeleted);
            builder.HasIndex(x => x.IsActive);

            // Relationships
            builder.HasOne(x => x.Car)
                .WithMany()
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Soft Delete Filter
            builder.HasQueryFilter(x => !x.IsDeleted);

            // Default Values
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}

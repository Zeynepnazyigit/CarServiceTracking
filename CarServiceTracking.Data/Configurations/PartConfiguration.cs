using CarServiceTracking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarServiceTracking.Data.Configurations
{
    public class PartConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.ToTable("Parts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PartName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.PartCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Category)
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(x => x.StockQuantity)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.MinStockLevel)
                .IsRequired()
                .HasDefaultValue(5);

            builder.Property(x => x.Supplier)
                .HasMaxLength(200);

            builder.Property(x => x.SupplierContact)
                .HasMaxLength(200);

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
            builder.HasIndex(x => x.PartCode)
                .IsUnique()
                .HasDatabaseName("IX_Parts_PartCode");

            builder.HasIndex(x => x.Category)
                .HasDatabaseName("IX_Parts_Category");

            builder.HasIndex(x => x.IsDeleted)
                .HasDatabaseName("IX_Parts_IsDeleted");

            // Query Filter
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}

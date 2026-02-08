using CarServiceTracking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarServiceTracking.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PaymentDate)
                .IsRequired();

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(x => x.TransactionId)
                .HasMaxLength(100);

            builder.Property(x => x.Reference)
                .HasMaxLength(200);

            builder.Property(x => x.Notes)
                .HasMaxLength(500);

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(x => x.Invoice)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(x => x.InvoiceId)
                .HasDatabaseName("IX_Payments_InvoiceId");

            builder.HasIndex(x => x.PaymentDate)
                .HasDatabaseName("IX_Payments_PaymentDate");

            builder.HasIndex(x => x.IsDeleted)
                .HasDatabaseName("IX_Payments_IsDeleted");

            // Query Filter
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}

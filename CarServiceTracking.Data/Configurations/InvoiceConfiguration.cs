using CarServiceTracking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarServiceTracking.Data.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.InvoiceNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.InvoiceDate)
                .IsRequired();

            builder.Property(x => x.PartsTotal)
                .IsRequired()
                .HasPrecision(18, 2)
                .HasDefaultValue(0);

            builder.Property(x => x.LaborCost)
                .IsRequired()
                .HasPrecision(18, 2)
                .HasDefaultValue(0);

            builder.Property(x => x.SubTotal)
                .IsRequired()
                .HasPrecision(18, 2)
                .HasDefaultValue(0);

            builder.Property(x => x.TaxRate)
                .IsRequired()
                .HasPrecision(5, 2)
                .HasDefaultValue(20);

            builder.Property(x => x.TaxAmount)
                .IsRequired()
                .HasPrecision(18, 2)
                .HasDefaultValue(0);

            builder.Property(x => x.GrandTotal)
                .IsRequired()
                .HasPrecision(18, 2)
                .HasDefaultValue(0);

            builder.Property(x => x.PaidAmount)
                .IsRequired()
                .HasPrecision(18, 2)
                .HasDefaultValue(0);

            builder.Property(x => x.RemainingAmount)
                .IsRequired()
                .HasPrecision(18, 2)
                .HasDefaultValue(0);

            builder.Property(x => x.Notes)
                .HasMaxLength(1000);

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Relationships
            // Servis faturasi (opsiyonel)
            builder.HasOne(x => x.ServiceRequest)
                .WithOne(x => x.Invoice)
                .HasForeignKey<Invoice>(x => x.ServiceRequestId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Kiralama faturasi (opsiyonel)
            builder.HasOne(x => x.RentalAgreement)
                .WithOne(x => x.Invoice)
                .HasForeignKey<Invoice>(x => x.RentalAgreementId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(x => x.InvoiceNumber)
                .IsUnique()
                .HasDatabaseName("IX_Invoices_InvoiceNumber");

            // Filtered unique index: ServiceRequestId (NULL ve soft-deleted haric benzersiz)
            builder.HasIndex(x => x.ServiceRequestId)
                .IsUnique()
                .HasFilter("[ServiceRequestId] IS NOT NULL AND [IsDeleted] = 0")
                .HasDatabaseName("IX_Invoices_ServiceRequestId");

            // Filtered unique index: RentalAgreementId (NULL ve soft-deleted haric benzersiz)
            builder.HasIndex(x => x.RentalAgreementId)
                .IsUnique()
                .HasFilter("[RentalAgreementId] IS NOT NULL AND [IsDeleted] = 0")
                .HasDatabaseName("IX_Invoices_RentalAgreementId");

            builder.HasIndex(x => x.CustomerId)
                .HasDatabaseName("IX_Invoices_CustomerId");

            builder.HasIndex(x => x.PaymentStatus)
                .HasDatabaseName("IX_Invoices_PaymentStatus");

            builder.HasIndex(x => x.IsDeleted)
                .HasDatabaseName("IX_Invoices_IsDeleted");

            // Query Filter
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}

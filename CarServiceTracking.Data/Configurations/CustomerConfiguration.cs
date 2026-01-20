using CarServiceTracking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceTracking.Data.Configurations
{
    
        public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
        {
            public void Configure(EntityTypeBuilder<Customer> builder)
            {
                // Table Name
                builder.ToTable("Customers");

                // Primary Key
                builder.HasKey(c => c.Id);

                // Properties
                builder.Property(c => c.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(c => c.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                builder.Property(c => c.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                builder.Property(c => c.Address)
                    .HasMaxLength(500);

                builder.Property(c => c.City)
                    .HasMaxLength(100);

                builder.Property(c => c.Country)
                    .HasMaxLength(100);

                builder.Property(c => c.PostalCode)
                    .HasMaxLength(20);

                builder.Property(c => c.TaxNumber)
                    .HasMaxLength(50);

                builder.Property(c => c.CompanyName)
                    .HasMaxLength(200);

                builder.Property(c => c.Notes)
                    .HasMaxLength(1000);

                builder.Property(c => c.IsDeleted)
                    .IsRequired()
                    .HasDefaultValue(false);

                builder.Property(c => c.IsActive)
                    .IsRequired()
                    .HasDefaultValue(true);

                builder.Property(c => c.CreatedDate)
                    .IsRequired()
                    .HasDefaultValueSql("GETDATE()");

                builder.Property(c => c.ModifiedDate)
                    .IsRequired(false);

                // Indexes
                builder.HasIndex(c => c.Email)
                    .IsUnique()
                    .HasDatabaseName("IX_Customers_Email");

                builder.HasIndex(c => c.Phone)
                    .HasDatabaseName("IX_Customers_Phone");

                builder.HasIndex(c => c.IsDeleted)
                    .HasDatabaseName("IX_Customers_IsDeleted");

                builder.HasIndex(c => c.IsActive)
                    .HasDatabaseName("IX_Customers_IsActive");

                // Query Filter (Soft Delete)
                builder.HasQueryFilter(c => !c.IsDeleted);

                // Relationships - Şimdilik yok (ListItem, Vehicle, ServiceRecord oluşturulunca ekleyeceğiz)
            }

        }
}

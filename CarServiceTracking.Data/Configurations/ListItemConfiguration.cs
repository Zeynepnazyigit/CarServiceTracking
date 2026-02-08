using CarServiceTracking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarServiceTracking.Data.Configurations
{
    public class ListItemConfiguration : IEntityTypeConfiguration<ListItem>
    {
        public void Configure(EntityTypeBuilder<ListItem> builder)
        {
            builder.ToTable("ListItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.ListType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.SortOrder)
                .HasDefaultValue(0);

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
            builder.HasIndex(x => x.ListType)
                .HasDatabaseName("IX_ListItems_ListType");

            builder.HasIndex(x => x.IsDeleted)
                .HasDatabaseName("IX_ListItems_IsDeleted");

            builder.HasIndex(x => new { x.ListType, x.SortOrder })
                .HasDatabaseName("IX_ListItems_ListType_SortOrder");

            // Self-referencing relationship (Parent-Child)
            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Query Filter
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}

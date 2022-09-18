namespace Application.Modules.Core.Persistence.Configurations;

using Application.Modules.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        // Table.

        builder.ToTable("core_regions");

        // Properties.

        builder.Property(r => r.Id);

        builder.Property(r => r.M49Code)
            .HasColumnName("m49_code")
            .HasMaxLength(3)
            .IsFixedLength();

        builder.Property(r => r.Name)
            .HasMaxLength(60);

        // Indexes.

        builder.HasIndex(r => r.M49Code)
            .IsUnique();

        builder.HasIndex(r => r.Name)
            .IsUnique();
    }
}

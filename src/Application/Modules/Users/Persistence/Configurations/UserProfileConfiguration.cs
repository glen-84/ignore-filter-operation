namespace Application.Modules.Users.Persistence.Configurations;

using Application.Modules.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        // Table.

        builder.ToTable("users_profiles");

        // Properties.

        builder.HasKey(e => e.UserId);

        builder.Property(p => p.FirstName)
            .HasMaxLength(50);

        builder.Property(p => p.LastName)
            .HasMaxLength(50);

        builder.Property(p => p.DateOfBirth);

        builder.Property(p => p.RegionId);

        builder.Property(p => p.AboutMe)
            .HasMaxLength(500);

        // Indexes.

        // Relationships.

        builder.HasOne(p => p.User)
            .WithOne(u => u.Profile)
            .HasForeignKey<UserProfile>(p => p.UserId)
            .HasConstraintName("FK_6BBD6130A76ED395");

        builder.HasOne(p => p.Region);
    }
}

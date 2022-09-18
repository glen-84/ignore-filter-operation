namespace Application.Modules.Users.Persistence.Configurations;

using Application.Modules.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Table.

        builder.ToTable("users");

        // Properties.

        builder.Property(u => u.Id)
            .HasColumnType("int(11)");

        builder.Property(u => u.EmailAddress)
            .HasColumnName("email")
            .HasMaxLength(60);

        builder.Property(u => u.EmailVerifiedAt)
            .HasColumnType("datetime");

        builder.Property(u => u.Username)
            .HasMaxLength(20);

        builder.Property(u => u.UsernameSlug)
            .HasMaxLength(20);

        builder.Property(u => u.FusionAuthId);

        builder.Property(u => u.IpAddress)
            .HasMaxLength(45);

        builder.Property(u => u.LastActionAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(u => u.RegisteredAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(u => u.RegistrationCompletedAt)
            .HasColumnType("datetime");

        builder.Property(u => u.DeletedAt)
            .HasColumnType("datetime");

        // Indexes.

        builder.HasIndex(u => u.EmailAddress, "UNIQ_1483A5E9E7927C74")
            .IsUnique();

        builder.HasIndex(u => u.Username, "UNIQ_1483A5E9F85E0677")
            .IsUnique();

        builder.HasIndex(u => u.LastActionAt, "last_action_at_idx");

        builder.HasIndex(u => u.FusionAuthId, "UNIQ_1483A5E95F973335")
            .IsUnique();
    }
}

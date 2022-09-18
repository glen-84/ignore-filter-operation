namespace Application.Modules.Users.Persistence.Configurations;

using Application.Modules.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserIpAddressConfiguration : IEntityTypeConfiguration<UserIpAddress>
{
    public void Configure(EntityTypeBuilder<UserIpAddress> builder)
    {
        builder.ToTable("user_ip_addresses");

        builder.HasIndex(e => e.UserId, "IDX_711C027AA76ED395");

        builder.Property(e => e.Id)
            .HasColumnType("bigint(20)")
            .HasColumnName("id");

        builder.Property(e => e.IpAddress)
            .HasMaxLength(45)
            .HasColumnName("ip_address");

        builder.Property(e => e.LoggedAt)
            .HasColumnType("datetime")
            .HasColumnName("logged_at");

        builder.Property(e => e.UserId)
            .HasColumnType("int(11)")
            .HasColumnName("user_id");

        builder.HasOne(d => d.User)
            .WithMany(p => p.UserIpAddresses)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_711C027AA76ED395");
    }
}

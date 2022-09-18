namespace Application.Modules.Core.Persistence;

using System.Reflection;
using Application.Modules.Core.Entities;
using Application.Modules.Users.Entities;
using Microsoft.EntityFrameworkCore;

public sealed partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        // Lazy loading is not needed and can lead to performance issues.
        this.ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<Region> Regions { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<UserIpAddress> UserIpAddresses { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

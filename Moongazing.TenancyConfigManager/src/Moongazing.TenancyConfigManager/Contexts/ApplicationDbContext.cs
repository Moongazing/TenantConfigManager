using Microsoft.EntityFrameworkCore;
using Moongazing.TenancyConfigManager.Models;

namespace Moongazing.TenancyConfigManager.Contexts;

public class ApplicationDbContext : DbContext
{
    public DbSet<TenantConfiguration> TenantConfigurations { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TenantConfiguration>().HasIndex(tc => new { tc.TenantId, tc.Key }).IsUnique();
    }
}
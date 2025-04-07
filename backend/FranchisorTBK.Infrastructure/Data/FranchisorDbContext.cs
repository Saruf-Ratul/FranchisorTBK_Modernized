using FranchisorTBK.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FranchisorTBK.Infrastructure.Data;

public class FranchisorDbContext : DbContext
{
    public FranchisorDbContext(DbContextOptions<FranchisorDbContext> options)
        : base(options) { }

    public DbSet<Franchisee> Franchisees => Set<Franchisee>();
    public DbSet<KpiResult> KpiResults => Set<KpiResult>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Franchisee>(entity =>
        {
            entity.HasKey(f => f.Id);
            entity.Property(f => f.Name).IsRequired().HasMaxLength(100);
            entity.HasMany(f => f.KpiResults)
                  .WithOne(k => k.Franchisee)
                  .HasForeignKey(k => k.FranchiseeId);
        });

        modelBuilder.Entity<KpiResult>(entity =>
        {
            entity.HasKey(k => k.Id);
        });
    }
}

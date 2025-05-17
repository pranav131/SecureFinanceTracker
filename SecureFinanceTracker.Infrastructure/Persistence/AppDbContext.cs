using Microsoft.EntityFrameworkCore;
using SecureFinanceTracker.Domain.Entities;

namespace SecureFinanceTracker.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Category).IsRequired().HasMaxLength(100);
            entity.Property(t => t.Amount).HasColumnType("decimal(18,2)");
        });
    }
}

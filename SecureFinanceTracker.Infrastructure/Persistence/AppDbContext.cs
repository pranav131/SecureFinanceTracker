using Microsoft.EntityFrameworkCore;
using SecureFinanceTracker.Domain.Entities;

namespace SecureFinanceTracker.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Transaction> Transactions => Set<Transaction>();

    public DbSet<User> Users { get; set; }

    public DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Category).IsRequired().HasMaxLength(100);
            entity.Property(t => t.Amount).HasColumnType("decimal(18,2)");
        });

         modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.HasIndex(u => u.Username).IsUnique();
            entity.Property(u => u.Username).IsRequired().HasMaxLength(100);
            entity.Property(u => u.PasswordHash).IsRequired();
        });
    }
}

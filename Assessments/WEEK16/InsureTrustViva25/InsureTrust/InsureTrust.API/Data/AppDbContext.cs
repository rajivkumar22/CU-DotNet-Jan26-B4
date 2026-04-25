using Microsoft.EntityFrameworkCore;
using InsureTrust.API.Models;

namespace InsureTrust.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>().HasIndex(p => p.PaymentNumber).IsUnique();
        modelBuilder.Entity<Payment>().Property(p => p.Amount).HasPrecision(18, 2);
    }
}

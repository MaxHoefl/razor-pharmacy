using Microsoft.EntityFrameworkCore;
using Razor.Pharmacy.Domain.Entities;

namespace Razor.Pharmacy.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<PharmacyItem> Items { get; set; }

    public DbSet<Basket> Baskets { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
    //
    //     // Orders - Items
    //     // configure the key as a composite between OrderId and ItemId
    //     modelBuilder.Entity<Order_Item>().HasKey(oi => new
    //     {
    //         oi.OrderId,
    //         oi.ItemId
    //     });
    //
    //     // configure that one order can have many items
    //     modelBuilder.Entity<Order_Item>()
    //         .HasOne(oi => oi.Order)
    //         .WithMany(o => o.Items)
    //         .HasForeignKey(oi => oi.OrderId);
    //
    //     // configure that one item can belong to many orders
    //     modelBuilder.Entity<Order_Item>()
    //         .HasOne(oi => oi.Item)
    //         .WithMany(i => i.)
    // }
}
using Microsoft.EntityFrameworkCore;
using Razor.Pharmacy.Domain.Entities;
using Razor.Pharmacy.Domain.Enums;

namespace Razor.Pharmacy.Infrastructure.Persistence;

public class DbInitializer
{
    private readonly AppDbContext _context;

    public DbInitializer(AppDbContext context)
    {
        _context = context;
    }

    public void Run()
    {
        //_context.Database.Migrate();
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        var item0 = new PharmacyItem()
            { ItemId = 0, Price = (decimal)1.50, Name = "Bepanthen", RequiresPrescription = false };

        var item1 = new PharmacyItem()
            { ItemId = 1, Price = (decimal)2.00, Name = "Fenistil", RequiresPrescription = false };

        var item2 = new PharmacyItem()
            { ItemId = 2, Price = (decimal)2.50, Name = "Thomapyrin", RequiresPrescription = false };

        var item3 = new PharmacyItem()
            { ItemId = 3, Price = (decimal)1.25, Name = "Grippostad", RequiresPrescription = false };

        var item4 = new PharmacyItem()
            { ItemId = 4, Price = (decimal)1.50, Name = "Eucerin Face Sun Creme", RequiresPrescription = false };

        var item5 = new PharmacyItem()
            { ItemId = 5, Price = (decimal)3.75, Name = "Voltaren", RequiresPrescription = false };

        if (!_context.Items.Any())
        {
            _context.Items.AddRange(new List<PharmacyItem>()
            {
                item0,
                item1,
                item2,
                item3,
                item4,
                item5
            });
        }


        var basket = new Basket()
        {
            BasketId = 0,
            ClientId = 0,
            Items = new List<PharmacyItem>() { item0 },
            OfferCode = "FOO123"
        };


        if (!_context.Baskets.Any())
        {
            _context.Baskets.AddRange(new List<Basket>() { basket });
        }

        var order0 = new Order()
        {
            ClientId = 0,
            Items = new List<PharmacyItem>() { item0 },
            OrderId = 0,
            OrderStatus = OrderStatus.InProgress,
            PercentageDiscount = 0,
            TotalPrice = 1
        };

        if (!_context.Orders.Any())
        {
            _context.Orders.AddRange(new List<Order>() { order0 });
        }

        if (!_context.Customers.Any())
        {
            _context.Customers.AddRange(new List<Customer>()
            {
                new Customer()
                {
                    ClientId = 0,
                    EmailAddress = "max@online.de",
                    FirstName = "Max",
                    LastName = "Moore",
                    PostCode = "99999",
                    Street = "Candyroad 7",
                    Baskets = new List<Basket>() { basket },
                    Orders = new List<Order>() { order0 }
                }
            });
        }

        _context.SaveChanges();
    }
}
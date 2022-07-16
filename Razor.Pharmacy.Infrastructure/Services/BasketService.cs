using Razor.Pharmacy.Application.Services;
using Razor.Pharmacy.Domain.Entities;
using Razor.Pharmacy.Infrastructure.Persistence;

namespace Razor.Pharmacy.Infrastructure.Services;

public class BasketService : IBasketService
{
    private readonly AppDbContext _context;

    public BasketService(AppDbContext context)
    {
        _context = context;
    }

    public Basket? GetById(int basketId)
    {
        return _context.Baskets.Find(basketId);
    }

    public ICollection<Basket> GetByCustomerId(int customerId)
    {
        return _context.Baskets.Where(b => b.ClientId == customerId).ToList();
    }

    public void AddItemToBasket(int basketId, PharmacyItem item)
    {
        var basket = _context.Baskets.Find(basketId);
        if (basket == null) return;
        basket.Items ??= new List<PharmacyItem>();
        basket.Items.Add(item);
        _context.Baskets.Update(basket);
    }
}
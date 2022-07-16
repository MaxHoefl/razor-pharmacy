using Razor.Pharmacy.Domain.Entities;

namespace Razor.Pharmacy.Application.Services;

public interface IBasketService
{
    Basket? GetById(int basketId);

    ICollection<Basket> GetByCustomerId(int customerId);

    void AddItemToBasket(int basketId, PharmacyItem item);
}
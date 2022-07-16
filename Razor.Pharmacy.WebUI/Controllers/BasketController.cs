using Microsoft.AspNetCore.Mvc;
using Razor.Pharmacy.Domain.Entities;
using Razor.Pharmacy.Infrastructure.Services;

namespace Razor.Pharmacy.WebUI.Controllers;

public class BasketController : Controller
{
    private readonly BasketService _basketService;

    public BasketController(BasketService basketService)
    {
        _basketService = basketService;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    public void AddToBasket(int customerId, PharmacyItem item)
    {
        _basketService.AddItemToBasket(customerId, item);
    }
}
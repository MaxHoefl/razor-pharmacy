using Microsoft.AspNetCore.Mvc;
using Razor.Pharmacy.Infrastructure.Services;

namespace Razor.Pharmacy.WebUI.Controllers;

public class ShopController : Controller
{
    private readonly PharmacyItemService _service;

    public ShopController(PharmacyItemService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        var data = _service.GetAll().ToList();
        return View(data);
    }
}
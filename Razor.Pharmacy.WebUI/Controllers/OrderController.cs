using Razor.Pharmacy.Application.Services;

namespace Razor.Pharmacy.WebUI.Controllers;

public class OrderController
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service)
    {
        _service = service;
    }


}
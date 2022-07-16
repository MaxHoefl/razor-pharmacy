using Razor.Pharmacy.Application.Services;
using Razor.Pharmacy.Domain.Entities;
using Razor.Pharmacy.Infrastructure.Persistence;

namespace Razor.Pharmacy.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public List<Order> GetOrdersByClientId(int clientId)
    {
        var orders = _context.Orders.Where(order => order.ClientId == clientId);
        return orders.ToList();
    }

    public Order? GetOrderById(int orderId)
    {
        var order = _context.Orders.Find(orderId);
        return order;
    }

    public void InsertOrder(Order order)
    {
        _context.Orders.Add(order);
    }

    public void UpdateOrder(Order order)
    {
        _context.Orders.Update(order);
    }

    public void DeleteOrder(Order order)
    {
        _context.Orders.Remove(order);
    }
}
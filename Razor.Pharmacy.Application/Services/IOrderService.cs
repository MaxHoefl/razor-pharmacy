using Razor.Pharmacy.Domain.Entities;

namespace Razor.Pharmacy.Application.Services;

public interface IOrderService
{
    List<Order> GetOrdersByClientId(int clientId);

    Order? GetOrderById(int orderId);

    void InsertOrder(Order order);

    void UpdateOrder(Order order);

    void DeleteOrder(Order order);
}
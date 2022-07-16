using FluentValidation;
using Razor.Pharmacy.Domain.Entities;
using Razor.Pharmacy.Domain.Enums;

namespace Razor.Pharmacy.Domain.Validators;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(order => order.TotalPrice).GreaterThanOrEqualTo(0);
        RuleFor(order => order.Items).NotNull();
        RuleFor(order => order.Items).NotEmpty();
        RuleFor(order => order.PercentageDiscount).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
        RuleFor(order => order.OrderStatus).Equal(OrderStatus.ReadyForPickup).When(order => order.PickupTime != null);
        RuleFor(order => order.PickupTime).NotNull().When(order => order.OrderStatus == OrderStatus.ReadyForPickup);

    }
}
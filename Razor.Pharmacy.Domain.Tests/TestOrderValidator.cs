using Razor.Pharmacy.Domain.Entities;
using Razor.Pharmacy.Domain.Enums;
using Razor.Pharmacy.Domain.Validators;

namespace Razor.Pharmacy.Domain.Tests;

public class UnitTest1
{
    private readonly OrderValidator _validator = new();

    [Fact]
    public void Validation_Error_Order_TotalPrice_Is_Negative()
    {
        var order = new Order()
        {
            OrderId = 0,
            ClientId = 0,
            OrderStatus = OrderStatus.InProgress,
            Items = new List<PharmacyItem>()
            {
                new PharmacyItem()
                {
                    ItemId = 0,
                    Name = "Aspirin",
                    Price = 1,
                    Quantity = 1,
                    RequiresPrescription = false
                }
            },
            TotalPrice = -1
        };

        var result = _validator.Validate(order);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors,
            error => error.PropertyName.Equals("TotalPrice"));
    }

    [Fact]
    public void Validation_Error_Order_Discount_Out_Of_Bounds()
    {
        var order = new Order()
        {
            OrderId = 0,
            ClientId = 0,
            OrderStatus = OrderStatus.InProgress,
            Items = new List<PharmacyItem>()
            {
                new PharmacyItem()
                {
                    ItemId = 0,
                    Name = "Aspirin",
                    Price = 1,
                    Quantity = 1,
                    RequiresPrescription = false
                }
            },
            TotalPrice = 1,
            PercentageDiscount = 2
        };

        var result = _validator.Validate(order);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors,
            error => error.PropertyName.Equals("PercentageDiscount"));
    }

    [Fact]
    public void Validation_Error_Order_Status_Not_Ready_When_PickupTime_Is_Set()
    {
        var order = new Order()
        {
            OrderId = 0,
            ClientId = 0,
            OrderStatus = OrderStatus.InProgress,
            Items = new List<PharmacyItem>()
            {
                new PharmacyItem()
                {
                    ItemId = 0,
                    Name = "Aspirin",
                    Price = 1,
                    Quantity = 1,
                    RequiresPrescription = false
                }
            },
            TotalPrice = 1,
            PercentageDiscount = 0,
            PickupTime = new DateTime(2020, 1, 1)
        };

        var result = _validator.Validate(order);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, error => error.PropertyName.Equals("OrderStatus"));
    }

    [Fact]
    public void Validation_Error_PickupTime_Not_Set_When_ReadyForPickup()
    {
        var order = new Order()
        {
            OrderId = 0,
            ClientId = 0,
            OrderStatus = OrderStatus.ReadyForPickup,
            Items = new List<PharmacyItem>()
            {
                new PharmacyItem()
                {
                    ItemId = 0,
                    Name = "Aspirin",
                    Price = 1,
                    Quantity = 1,
                    RequiresPrescription = false
                }
            },
            TotalPrice = 1,
            PercentageDiscount = 0,
            PickupTime = null
        };

        var result = _validator.Validate(order);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, error => error.PropertyName.Equals("PickupTime"));
    }
}
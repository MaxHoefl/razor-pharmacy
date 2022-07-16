using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Razor.Pharmacy.Domain.Enums;

namespace Razor.Pharmacy.Domain.Entities;

public class Order
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int OrderId { get; set; }

    public int ClientId { get; set; }

    [Display(Name = "Order Status")]
    public OrderStatus OrderStatus { get; set; }

    [Display(Name = "Pickup Time")]
    public DateTime? PickupTime { get; set; } = null;

    public ICollection<PharmacyItem>? Items { get; set; }

    [Display(Name = "Total Price")]
    public decimal TotalPrice { get; set; }

    [Display(Name = "Order Discount in Percent")]
    public float PercentageDiscount { get; set; } = 0;
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Razor.Pharmacy.Domain.Entities;

public class Customer
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ClientId { get; set; }

    [Display(Name = "FirstName")]
    public string? FirstName { get; set; }

    [Display(Name = "LastName")]
    public string? LastName { get; set; }

    [Display(Name = "Street")]
    public string? Street { get; set; }

    [Display(Name = "PostCode")]
    public string? PostCode { get; set; }

    [Display(Name = "EmailAddress")]
    public string? EmailAddress { get; set; }

    public ICollection<Basket>? Baskets { get; set; }

    public ICollection<Order>? Orders { get; set; }
}
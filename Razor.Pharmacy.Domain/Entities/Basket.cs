using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Razor.Pharmacy.Domain.Entities;

public class Basket
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int BasketId { get; set; }

    public int ClientId { get; set; }

    public ICollection<PharmacyItem>? Items { get; set; }

    [Display(Name = "Offer Code")]
    public string? OfferCode { get; set; }
}
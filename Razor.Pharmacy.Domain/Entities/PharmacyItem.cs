using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Razor.Pharmacy.Domain.Entities;

public class PharmacyItem
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ItemId { get; set; }

    public string? Name { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; } = 0;

    public bool RequiresPrescription { get; set; }
}
using Razor.Pharmacy.Domain.Entities;

namespace Razor.Pharmacy.Application.Services;

public interface IPharmacyItemService
{
    ICollection<PharmacyItem> GetAll();
}
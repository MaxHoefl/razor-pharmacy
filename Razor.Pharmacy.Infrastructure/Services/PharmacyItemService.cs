using Razor.Pharmacy.Application.Services;
using Razor.Pharmacy.Domain.Entities;
using Razor.Pharmacy.Infrastructure.Persistence;

namespace Razor.Pharmacy.Infrastructure.Services;

public class PharmacyItemService : IPharmacyItemService
{
    private readonly AppDbContext _context;

    public PharmacyItemService(AppDbContext context)
    {
        _context = context;
    }

    public ICollection<PharmacyItem> GetAll()
    {
        return _context.Items.ToList();
    }
}
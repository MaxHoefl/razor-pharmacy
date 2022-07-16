using FluentValidation;
using Razor.Pharmacy.Domain.Entities;

namespace Razor.Pharmacy.Domain.Validators;

public class PharmacyItemValidator : AbstractValidator<PharmacyItem>
{
    public PharmacyItemValidator()
    {
        RuleFor(item => item.Price).GreaterThanOrEqualTo(0);
        RuleFor(item => item.Quantity).GreaterThanOrEqualTo(0);
        RuleFor(item => item.Name).MaximumLength(50);
    }
}
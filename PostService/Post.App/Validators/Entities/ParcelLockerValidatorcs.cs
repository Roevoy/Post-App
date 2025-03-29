using FluentValidation;
using POST.Core.Models;

namespace Post.App.Validators
{
    public class ParcelLockerValidator : AbstractValidator<ParcelLocker>
    {
        public ParcelLockerValidator()
        {
            RuleFor(pl => pl.Id)
                .NotEmpty().WithMessage("ParcelLocker ID is required.");
            RuleFor(pl => pl.AddressId)
                .NotEmpty().WithMessage("Adress ID is required.");
        }
    }
}

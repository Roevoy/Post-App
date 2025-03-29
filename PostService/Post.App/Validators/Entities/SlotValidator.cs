using FluentValidation;
using POST.Core.Models;

namespace Post.App.Validators
{
    public class SlotValidator : AbstractValidator<Slot>
    {
        public SlotValidator()
        {
            RuleFor(slot => slot.Id)
                .NotEmpty().WithMessage("Slot ID is required.");
            RuleFor(slot => slot.ParcelLockerId)
                .NotEmpty().WithMessage("Parcel locker ID is required.");
            RuleFor(slot => slot.Size)
              .NotEmpty().WithMessage("Size is required.");
            RuleFor(slot => slot.Number)
              .NotEmpty().WithMessage("Number is required.")
              .InclusiveBetween(1, 9999).WithMessage("Number must be between 1 and 9999.");
        }
    }
}

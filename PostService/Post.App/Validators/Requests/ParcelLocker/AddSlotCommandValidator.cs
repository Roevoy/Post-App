
using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators.Requests.ParcelLocker
{
    public class AddSlotCommandValidator : AbstractValidator<AddSlotCommand>
    {
        public AddSlotCommandValidator() 
        {
            RuleFor(command => command.ParcelLockerId)
                .NotEmpty().WithMessage("ParcelLocker ID is required.");
            RuleFor(command => command.Size)
                .NotEmpty().WithMessage("Slot size is required.")
                .IsInEnum().WithMessage("Incorrect size value.");

            RuleFor(command => command.Number)
                .NotEmpty().WithMessage("Slot number is required.")
                .InclusiveBetween(1, 9999).WithMessage("Slot number must be between 1 and 9999.");
        }
    }
}

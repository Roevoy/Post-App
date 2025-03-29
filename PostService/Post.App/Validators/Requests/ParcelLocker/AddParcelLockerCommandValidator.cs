using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class AddParcelLockerCommandValidator : AbstractValidator<AddParcelLockerCommand>
    {
        public AddParcelLockerCommandValidator()
        {
            RuleFor(pl => pl.AddressId)
                .NotEmpty().WithMessage("Adress ID is required.");
        }
    }
}
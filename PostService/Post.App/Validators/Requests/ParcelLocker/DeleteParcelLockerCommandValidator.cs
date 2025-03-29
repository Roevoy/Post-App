using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class DeleteParcelLockerCommandValidator : AbstractValidator<DeleteParcelLockerCommand>
    {
        public DeleteParcelLockerCommandValidator()
        {
            RuleFor(pl => pl.Id)
                .NotEmpty().WithMessage("Parcel locker ID is required.");
        }
    }
}
using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class GetParcelLockerByIdQueryValidator : AbstractValidator<GetParcelLockerByIdQuery>
    {
        public GetParcelLockerByIdQueryValidator()
        {
            RuleFor(pl => pl.Id)
                .NotEmpty().WithMessage("Parcel locker ID is required.");
        }
    }
}
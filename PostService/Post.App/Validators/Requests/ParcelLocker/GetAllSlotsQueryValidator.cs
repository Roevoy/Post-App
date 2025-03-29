using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class GetAllSlotsQueryValidator : AbstractValidator<GetAllSlotsQuery>
    {
        public GetAllSlotsQueryValidator()
        {
            RuleFor(pl => pl.ParcelLockerId)
                .NotEmpty().WithMessage("Parcel locker ID is required.");
        }
    }
}
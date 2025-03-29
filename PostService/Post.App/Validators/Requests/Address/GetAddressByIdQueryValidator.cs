using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class GetAddressByIdQueryValidator : AbstractValidator<GetAddressByIdQuery>
    {
        public GetAddressByIdQueryValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("Address ID is required.");
        }
    }
}

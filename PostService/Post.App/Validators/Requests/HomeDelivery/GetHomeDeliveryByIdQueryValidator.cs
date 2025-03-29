using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class GetHomeDeliveryByIdQueryValidator : AbstractValidator<GetHomeDeliveryByIdQuery>
    {
        public GetHomeDeliveryByIdQueryValidator()
        {
            RuleFor(hd => hd.Id)
                .NotEmpty().WithMessage("Home delivery ID is required.");
        }
    }
}
using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class DeleteHomeDeliveryCommandValidator : AbstractValidator<DeleteHomeDeliveryCommand>
    {
        public DeleteHomeDeliveryCommandValidator()
        {
            RuleFor(hd => hd.Id)
                .NotEmpty().WithMessage("Home delivery ID is required.");
        }
    }
}
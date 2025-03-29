using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class AddHomeDeliveryCommandValidator : AbstractValidator<AddHomeDeliveryCommand>
    {
        public AddHomeDeliveryCommandValidator()
        {
            RuleFor(hd => hd.addressId)
                .NotEmpty().WithMessage("Address ID is required.");
            RuleFor(hd => hd.recipientId)
                .NotEmpty().WithMessage("Recipient ID is required.");
        }
    }
}
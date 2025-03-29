using FluentValidation;
using Post.Core.Models;

namespace Post.App.Validators
{
    public class HomeDeliveryValidator : AbstractValidator<HomeDelivery>
    {
        public HomeDeliveryValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("HomeDelivery ID is required.");
            RuleFor(d => d.AddressId)
                .NotEmpty().WithMessage("Adress ID is required.");
            RuleFor(d => d.RecipientId)
              .NotEmpty().WithMessage("Recipient ID is required.");
        }
    }
}

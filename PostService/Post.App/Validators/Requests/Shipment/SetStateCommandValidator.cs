using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class SetStateCommandValidator : AbstractValidator<SetStateCommand>
    {
        public SetStateCommandValidator()
        {
            RuleFor(b => b.ShipmentId)
                .NotEmpty().WithMessage("Shipment ID is required.");
            RuleFor(b => b.State)
                .NotEmpty().WithMessage("New state is required.");
        }
    }
}
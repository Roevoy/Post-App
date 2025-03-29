using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class AddBoxCommandValidator : AbstractValidator<AddBoxCommand>
    {
        public AddBoxCommandValidator()
        {
            RuleFor(b => b.ShipmentId)
                .NotEmpty().WithMessage("Shipment ID is required.");
            RuleFor(b => b.BoxSize)
                .NotEmpty().WithMessage("Box size is required.");
            RuleFor(b => b.BoxWeight)
              .NotEmpty().WithMessage("Box weight is required.")
              .InclusiveBetween(0, 40).WithMessage("Box weight must be between 0 and 40 kg.");
            RuleFor(b => b.BoxDescription)
             .MaximumLength(200).WithMessage("Description must have at most 200 symbols.");
        }
    }
}
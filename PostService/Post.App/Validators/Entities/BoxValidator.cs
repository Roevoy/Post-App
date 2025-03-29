using FluentValidation;
using POST.Core.Models;

namespace Post.App.Validators
{
    public class BoxValidator : AbstractValidator<Box>
    {
        public BoxValidator()
        {
            RuleFor(b => b.Id)
                .NotEmpty().WithMessage("Box ID is required.");
            RuleFor(b => b.Size)
                .NotEmpty().WithMessage("Size is required.");
            RuleFor(b => b.Weight)
              .NotEmpty().WithMessage("Weight is required.")
              .InclusiveBetween(0, 40).WithMessage("Weight must be between 0 and 40 kg.");
            RuleFor(b => b.ShipmentId)
              .NotEmpty().WithMessage("Shipment ID is required.");
            RuleFor(b => b.Description)
             .MaximumLength(200).WithMessage("Description must have at most 200 symbols.");
        }
    }
}

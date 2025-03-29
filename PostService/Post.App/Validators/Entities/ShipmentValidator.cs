using FluentValidation;
using POST.Core.Models;

namespace Post.App.Validators
{
    public class ShipmentValidator : AbstractValidator<Shipment>
    {
        public ShipmentValidator()
        {
            RuleFor(sh => sh.Id)
                .NotEmpty().WithMessage("Shipment ID is required.");
            //RuleFor(sh => sh.State)
            //   .NotEmpty().WithMessage("Shipment state is required.");
            RuleFor(sh => sh.SenderId)
                .NotEmpty().WithMessage("Sender ID is required.");
            RuleFor(sh => sh.DepartmentSenderId)
              .NotEmpty().WithMessage("Department-Sender ID is required.");
            RuleFor(sh => sh.DestinationId)
              .NotEmpty().WithMessage("Destination ID is required.");
            RuleFor(sh => sh.Description)
             .MaximumLength(200).WithMessage("Description must have at most 200 symbols.");
        }
    }
}

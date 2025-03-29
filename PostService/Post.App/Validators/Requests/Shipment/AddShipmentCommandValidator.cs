using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class AddShipmentCommandValidator : AbstractValidator<AddShipmentCommand>
    {
        public AddShipmentCommandValidator()
        {
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
using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class DeleteShipmentCommandValidator : AbstractValidator<DeleteShipmentCommand>
    {
        public DeleteShipmentCommandValidator()
        {
            RuleFor(b => b.Id)
                .NotEmpty().WithMessage("Shipment ID is required.");
        }
    }
}
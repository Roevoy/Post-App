using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class GetShipmentByIdQueryValidator : AbstractValidator<GetShipmentByIdQuery>
    {
        public GetShipmentByIdQueryValidator()
        {
            RuleFor(b => b.Id)
                .NotEmpty().WithMessage("Shipment ID is required.");
        }
    }
}
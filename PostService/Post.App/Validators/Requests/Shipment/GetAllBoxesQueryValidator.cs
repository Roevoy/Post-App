using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class GetAllBoxesQueryValidator : AbstractValidator<GetAllBoxesQuery>
    {
        public GetAllBoxesQueryValidator()
        {
            RuleFor(b => b.ShipmentId)
                .NotEmpty().WithMessage("Shipment ID is required.");
        }
    }
}
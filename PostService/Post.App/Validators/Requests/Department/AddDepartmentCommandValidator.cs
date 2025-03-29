using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class AddDepartmentCommandValidator : AbstractValidator<AddDepartmentCommand>
    {
        public AddDepartmentCommandValidator()
        {
            RuleFor(d => d.AddressId)
                .NotEmpty().WithMessage("Adress ID is required.");
            RuleFor(d => d.Number)
              .NotEmpty().WithMessage("Number is required.")
              .InclusiveBetween(1, 9999).WithMessage("Number must be beetween 1 and 9999.");
        }
    }
}

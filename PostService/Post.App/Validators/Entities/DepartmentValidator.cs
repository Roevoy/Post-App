using FluentValidation;
using POST.Core.Models;

namespace Post.App.Validators
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Department ID is required.");
            RuleFor(d => d.AddressId)
                .NotEmpty().WithMessage("Adress ID is required.");
            RuleFor(d => d.Number)
              .NotEmpty().WithMessage("Number is required.")
              .InclusiveBetween(1, 9999).WithMessage("Number must be beetween 1 and 9999.");
        }
    }
}

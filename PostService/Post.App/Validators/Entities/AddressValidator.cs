using FluentValidation;
using POST.Core.Models;

namespace Post.App.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("Address ID is required.");
            RuleFor(a => a.Region)
                .NotEmpty().WithMessage("Region is required.")
                .Matches("^[a-zA-Z]+$").WithMessage("Region can't have any numbers.")
                .MaximumLength(20).WithMessage("Region must have at most 20 symbols.");
            RuleFor(a => a.Country)
              .NotEmpty().WithMessage("Country is required.")
              .Matches("^[a-zA-Z]+$").WithMessage("Country can't have any numbers.")
              .MaximumLength(100).WithMessage("Country must have at most 100 symbols.");
            RuleFor(a => a.Street)
              .NotEmpty().WithMessage("Street is required.")
              .MaximumLength(100).WithMessage("Street must have at most 100 symbols.");
            RuleFor(a => a.Number)
             .NotEmpty().WithMessage("Number is required.")
             .MaximumLength(10).WithMessage("Number must have at most 10 symbols.");
        }
    }
}

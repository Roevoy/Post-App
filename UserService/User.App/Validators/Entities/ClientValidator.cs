using FluentValidation;
using User.Core.Models;

namespace User.App.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator() 
        {
            RuleFor(client => client.Id)
                .NotEmpty().WithMessage("Client's ID is required.");
            RuleFor(client => client.FirstName)
                .NotEmpty().WithMessage("Client's name is required.")
                .Length(1, 30).WithMessage("Client's name must be between 1 and 30 characters long.");
            RuleFor(client => client.SecondName)
                .NotEmpty().WithMessage("Client's surname is required.")
                .Length(1, 30).WithMessage("Client's surname must be between 1 and 30 characters long.");
            RuleFor(client => client.ThirdName)
                .Length(1,30).WithMessage("Client's patronymic must be between 1 and 30 characters long.");
            RuleFor(client => client.Phone)
                .NotEmpty().WithMessage("Client's phone number is required.")
                .Matches(@"^\+?\d{10,15}$")
                .WithMessage("Client's phone number must be between 10 and 15 digits, start with '+'.");
            RuleFor(client => client.Email)
                .NotEmpty().WithMessage("Client's email is required.")
                .EmailAddress().WithMessage("Client's email is invalid.")
                .MaximumLength(200).WithMessage("Client's email can't be more then 200 symbols.");
            RuleFor(client => client.Birthday)
                .Must(date => date <= DateTime.Today.AddYears(-12)).WithMessage("Client's age must be not less then 12 years old.")
                .Must(date => date >= DateTime.Today.AddYears(-200)).WithMessage("Client's can't be more then 200 years old.");
            RuleFor(client => client.passwordHash)
                .NotEmpty().WithMessage("Client's password hash is required.");
        }
    }
}

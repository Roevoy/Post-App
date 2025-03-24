using FluentValidation;
using User.App.Requests;

namespace User.App.Validators.Requests
{
    public class AddEmployeeCommandValidator : AbstractValidator<AddEmployeeCommand>
    {
        public AddEmployeeCommandValidator() 
        {
            RuleFor(Employee => Employee.FirstName)
                .NotEmpty().WithMessage("Employee's name is required.")
                .Length(1, 30).WithMessage("Employee's name must be between 1 and 30 characters long.");
            RuleFor(Employee => Employee.SecondName)
                .NotEmpty().WithMessage("Employee's surname is required.")
                .Length(1, 30).WithMessage("Employee's surname must be between 1 and 30 characters long.");
            RuleFor(Employee => Employee.ThirdName)
                .Length(1, 30).WithMessage("Employee's patronymic must be between 1 and 30 characters long.");
            RuleFor(Employee => Employee.Age)
                .NotEmpty().WithMessage("Employee's age is required.")
                .InclusiveBetween(12, 200).WithMessage("Employee's age must be between 12 and 200 years old.");
            RuleFor(Employee => Employee.Phone)
                .NotEmpty().WithMessage("Employee's phone number is required.")
                .Matches(@"^\+?\d{10,15}$")
                .WithMessage("Employee's phone number must be between 10 and 15 digits, start with '+'.");
            RuleFor(Employee => Employee.Email)
                .NotEmpty().WithMessage("Employee's email is required.")
                .EmailAddress().WithMessage("Employee's email is invalid.")
                .MaximumLength(200).WithMessage("Employee's email can't be more then 200 symbols.");
            RuleFor(Employee => Employee.Birthday)
                .Must(date => date <= DateTime.Today.AddYears(-12)).WithMessage("Employee's age must be not less then 12 years old.")
                .Must(date => date >= DateTime.Today.AddYears(-200)).WithMessage("Employee's can't be more then 200 years old.");
        }
    }
}

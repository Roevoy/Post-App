using FluentValidation;
using User.Core.Models;

namespace User.App.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator() 
        {
            RuleFor(employee => employee.Id)
                .NotEmpty().WithMessage("Employee's ID is required.");
            RuleFor(employee => employee.FirstName)
                .NotEmpty().WithMessage("Employee's name is required.")
                .Length(1, 30).WithMessage("Employee's name must be between 1 and 30 characters long.");
            RuleFor(employee => employee.SecondName)
                .NotEmpty().WithMessage("Employee's surname is required.")
                .Length(1, 30).WithMessage("Employee's surname must be between 1 and 30 characters long.");
            RuleFor(employee => employee.ThirdName)
                .Length(1, 30).WithMessage("Employee's patronymic must be between 1 and 30 characters long.");
            RuleFor(employee => employee.Age)
                .NotEmpty().WithMessage("Employee's age is required.")
                .InclusiveBetween(18, 200).WithMessage("Employee's age must be between 18 and 200 years old.");
            RuleFor(employee => employee.Phone)
                .NotEmpty().WithMessage("Employee's phone number is required.")
                .Matches(@"^\+?\d{10,15}$")
                .WithMessage("Employee's phone number must be between 10 and 15 digits, start with '+'.");
            RuleFor(employee => employee.Email)
                .NotEmpty().WithMessage("Employee's email is required.")
                .EmailAddress().WithMessage("Employee's email is invalid.")
                .MaximumLength(200).WithMessage("Employee's email can't be more then 200 symbols.");
            RuleFor(employee => employee.Birthday)
                .Must(date => date <= DateTime.Today.AddYears(-18)).WithMessage("Employee's age must be not less then 18 years old.")
                .Must(date => date >= DateTime.Today.AddYears(-200)).WithMessage("Employee's can't be more then 200 years old.");
        }
    }
}

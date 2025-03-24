using FluentValidation;
using User.App.Requests;

namespace User.App.Validators.Requests
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator() 
        {
            RuleFor(Employee => Employee.Id)
                .NotEmpty().WithMessage("Employee's ID is required.");
        }
    }
}

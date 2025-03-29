using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Department ID is required.");
        }
    }
}
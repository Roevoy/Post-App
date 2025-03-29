using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class GetDepartmentByIdQueryValidator : AbstractValidator<GetDepartmentByIdQuery>
    {
        public GetDepartmentByIdQueryValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Department ID is required.");
        }
    }
}
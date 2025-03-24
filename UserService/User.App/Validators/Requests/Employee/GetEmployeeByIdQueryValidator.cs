using FluentValidation;
using User.App.Requests;

namespace User.App.Validators.Requests
{
    public class GetEmployeeByIdQueryValidator : AbstractValidator<GetEmployeeByIdQuery>
    {
        public GetEmployeeByIdQueryValidator() { }
    }
}

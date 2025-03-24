using FluentValidation;
using User.App.Requests;

namespace User.App.Validators.Requests
{
    public class GetClientByIdQueryValidator : AbstractValidator<GetEmployeeByIdQuery>
    {
        public GetClientByIdQueryValidator() { }
    }
}

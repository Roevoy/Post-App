using FluentValidation;
using User.App.Requests;

namespace User.App.Validators.Requests
{
    public class GetAllEmployeesQueryValidator : AbstractValidator<GetAllEmployeesQuery>
    {
        public GetAllEmployeesQueryValidator() { }
    }
}

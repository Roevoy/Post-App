using FluentValidation;
using User.App.Requests;

namespace User.App.Validators.Requests
{
    public class GetAllClientsQueryValidator : AbstractValidator<GetAllClientsQuery>
    {
        public GetAllClientsQueryValidator() { }
    }
}

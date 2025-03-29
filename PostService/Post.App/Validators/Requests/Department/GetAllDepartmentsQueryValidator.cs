using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class GetAllDepartmentsQueryValidator : AbstractValidator<GetAllDepartmentsQuery>
    {
        public GetAllDepartmentsQueryValidator()
        {

        }
    }
}
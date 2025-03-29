using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class GetAllParcelLockersQueryValidator : AbstractValidator<GetAllParcelLockersQuery>
    {
        public GetAllParcelLockersQueryValidator()
        {
        }
    }
}
using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class GetAllAddressesQueryValidator : AbstractValidator<GetAllAddressesQuery>
    {
        public GetAllAddressesQueryValidator()
        {
           
        }
    }
}
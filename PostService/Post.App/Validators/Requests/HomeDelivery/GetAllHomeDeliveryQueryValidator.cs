using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class GetAllHomeDeliveryQueryValidator : AbstractValidator<GetAllHomeDeliveryQuery>
    {
        public GetAllHomeDeliveryQueryValidator()
        {
        }
    }
}
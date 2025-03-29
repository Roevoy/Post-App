using FluentValidation;
using Post.App.Requests;

namespace Post.App.Validators
{
    public class GetAllShipmentsQueryValidator : AbstractValidator<GetAllShipmentsQuery>
    {
        public GetAllShipmentsQueryValidator()
        {
        }
    }
}
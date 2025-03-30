using FluentValidation;
using User.App.Requests;

namespace User.App.Validators.Requests.Client
{
    public class LoginQueryValidator : AbstractValidator<LoginClientQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(query => query.clientEmail)
                .NotEmpty().WithMessage("Client's email is required.")
                .EmailAddress().WithMessage("Client's email is invalid.")
                .MaximumLength(200).WithMessage("Client's email can't be more then 200 symbols.");
            RuleFor(query => query.clientPassword)
               .NotEmpty().WithMessage("Client's password is required.")
               .MinimumLength(8).WithMessage("Password must contain at least 8 symbols.")
               .Matches(@"[A-Z]").WithMessage("Password must contain at least one big letter.")
               .Matches(@"[a-z]").WithMessage("Password must contain at least one small letter.")
               .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.");
        }
    }
}

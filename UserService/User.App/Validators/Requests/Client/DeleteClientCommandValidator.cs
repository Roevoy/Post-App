using FluentValidation;
using User.App.Requests;

namespace User.App.Validators.Requests
{
    public class DeleteClientCommandValidator : AbstractValidator<DeleteClientCommand>
    {
        public DeleteClientCommandValidator() 
        {
            RuleFor(client => client.Id)
                .NotEmpty().WithMessage("Client's ID is required.");
        }
    }
}

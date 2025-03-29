using FluentValidation;
using Post.App.Requests;

public class DeleteAddressCommandValidator : AbstractValidator<DeleteAddressCommand>
{
    public DeleteAddressCommandValidator()
    {
        RuleFor(a => a.Id)
                .NotEmpty().WithMessage("Address ID is required.");
    }
}
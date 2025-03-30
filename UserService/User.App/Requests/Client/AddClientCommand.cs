using MediatR;
using User.App.Validators;
using User.App.Interfaces;
using User.Core.Models;
using FluentValidation;
namespace User.App.Requests
{
    public class AddClientCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string? ThirdName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
    public class AddClientHandler : IRequestHandler<AddClientCommand, Guid>
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IClientRepository _clientRepository;
        private readonly ClientValidator _clientValidator;
        public AddClientHandler(IClientRepository clientRepository, ClientValidator clientValidator, 
            IPasswordHasher passwordHasher)
        {
            _clientRepository = clientRepository;
            _clientValidator = clientValidator;
            _passwordHasher = passwordHasher;
        }
        public async Task<Guid> Handle(AddClientCommand command, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordHasher.Generate(command.Password);
            var client = Client.FacroryMethod(command.FirstName, command.SecondName,
                command.Email, command.Phone, command.Birthday, hashedPassword, command.ThirdName);
            await _clientValidator.ValidateAndThrowAsync(client, cancellationToken);
            await _clientRepository.Add(client);
            return client.Id;
        }
    }
}

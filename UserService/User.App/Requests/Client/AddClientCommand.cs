using FluentValidation;
using MediatR;
using User.App.Validators;
using User.Core.Abstractions.Repositories;
using User.Core.Models;
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
    }
    public class AddClientHandler : IRequestHandler<AddClientCommand, Guid>
    {
        private readonly IClientRepository _clientRepository;
        private readonly ClientValidator _clientValidator;
        public AddClientHandler(IClientRepository clientRepository, ClientValidator clientValidator)
        {
            _clientRepository = clientRepository;
            _clientValidator = clientValidator;
        }
        public async Task<Guid> Handle(AddClientCommand command, CancellationToken cancellationToken)
        {
            var client = Client.FacroryMethod(command.FirstName, command.SecondName, 
                command.Email, command.Phone, command.Birthday, command.ThirdName);
            await _clientValidator.ValidateAndThrowAsync(client, cancellationToken);
            await _clientRepository.Add(client);
            return client.Id;
        }
    }
}

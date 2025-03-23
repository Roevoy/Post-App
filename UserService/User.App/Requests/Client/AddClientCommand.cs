using MediatR;
using User.Core.Abstractions.Repositories;
using User.Core.Models;
namespace User.App.Requests
{
    public class AddClientCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string? ThirdName { get; set; }
        public int Age { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    public class AddClientHandler : IRequestHandler<AddClientCommand, Guid>
    {
        private readonly IClientRepository _clientRepository;
        public AddClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<Guid> Handle(AddClientCommand command, CancellationToken cancellationToken)
        {
            var client = new Client //replace on factory
            {
                FirstName = command.FirstName,
                SecondName = command.SecondName,
                ThirdName = command.ThirdName,
                Age = command.Age,
                Birthday = command.Birthday,
                Email = command.Email,
                Phone = command.Phone
            };
            await _clientRepository.Add(client);
            return client.Id;
    }
    }
}

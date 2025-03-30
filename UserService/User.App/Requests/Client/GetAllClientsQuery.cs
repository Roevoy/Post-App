using MediatR;
using User.App.Interfaces;
using User.Core.Models;

namespace User.App.Requests
{
    public class GetAllClientsQuery : IRequest<List<Client>>
    { }
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, List<Client>>
    {
        private readonly IClientRepository _clientRepository;
        public GetAllClientsHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<List<Client>> Handle(GetAllClientsQuery query, CancellationToken cancellationToken)
        {
            return await _clientRepository.GetAll(cancellationToken);
        }
    }
}

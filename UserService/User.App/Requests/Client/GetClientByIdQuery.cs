using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Core.Abstractions.Repositories;
using User.Core.Models;

namespace User.App.Requests
{
    public class GetClientByIdQuery : IRequest<Client>
    {
        public Guid Id { get; set; }
    }
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, Client>
    {
        private readonly IClientRepository _clientRepository;
        public GetClientByIdHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<Client> Handle (GetClientByIdQuery query, CancellationToken cancellationToken)
        {
            return await _clientRepository.GetById(query.Id);
        }
    }
}

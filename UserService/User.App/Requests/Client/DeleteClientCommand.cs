using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Core.Abstractions.Repositories;

namespace User.App.Requests
{
    public class DeleteClientCommand: IRequest<bool>
    {
        public Guid Id { get; set; }
    }
    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand, bool>
    {
        private readonly IClientRepository _clientRepository;
        public DeleteClientHandler(IClientRepository _clientRepository)
        {
            this._clientRepository = _clientRepository;
        }
        public async Task<bool> Handle (DeleteClientCommand command, CancellationToken cancellationToken)
        {
            await _clientRepository.Delete(command.Id);
            return true;
        }
    }
}

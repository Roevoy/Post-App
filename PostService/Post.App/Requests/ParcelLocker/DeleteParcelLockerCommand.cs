using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.App.Requests
{
    public class DeleteParcelLockerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
    public class DeleteParcelLcokerHandler : IRequestHandler<DeleteParcelLockerCommand, bool>
    {
        private readonly IParcelLockerRepository _lockerRepository;
        public DeleteParcelLcokerHandler(ParcelLockerRepository lockerRepository)
        {
            _lockerRepository = lockerRepository;
        }
        public async Task<bool> Handle(DeleteParcelLockerCommand command, CancellationToken cancellationToken)
        {
            return await _lockerRepository.DeleteById(command.Id);
        }
    }
}

using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;

namespace Post.App.Requests
{
    public class DeleteParcelLockerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
    public class DeleteParcelLcokerHandler : IRequestHandler<DeleteParcelLockerCommand, bool>
    {
        private readonly IParcelLockerRepository _lockerRepository;
        public DeleteParcelLcokerHandler(IParcelLockerRepository lockerRepository)
        {
            _lockerRepository = lockerRepository;
        }
        public async Task<bool> Handle(DeleteParcelLockerCommand command, CancellationToken cancellationToken)
        {
            return await _lockerRepository.DeleteById(command.Id);
        }
    }
}

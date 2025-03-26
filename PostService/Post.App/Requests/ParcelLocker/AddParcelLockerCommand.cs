
using MediatR;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class AddParcelLockerCommand : IRequest<Guid>
    {
        public Guid AddressId { get; set; }
        public Guid RecipientId { get; set; }
    }
    public class AddParcelLockerHandler : IRequestHandler<AddParcelLockerCommand, Guid>
    {
        private readonly IParcelLockerRepository _repository;
        public AddParcelLockerHandler(IParcelLockerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(AddParcelLockerCommand command, CancellationToken cancellationToken)
        {
            var parrcelLocker = new ParcelLocker
            {
                AddressId = command.AddressId,
                RecipientId = command.RecipientId,
            };
            return await _repository.Add(parrcelLocker);
        }
    }
}

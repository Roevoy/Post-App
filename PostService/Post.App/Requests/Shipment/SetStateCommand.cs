using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions;
using Post.Core.Abstractions.Repositories;

namespace Post.App.Requests
{
    public class SetStateCommand : IRequest<bool>
    {
        public Guid ShipmentId { get; set; }
        public State State { get; set; }
    }
    public class SetStateHandler : IRequestHandler<SetStateCommand, bool>
    {
        private readonly IShipmentRepository _shipmentRepository;
        public SetStateHandler(ShipmentRepository shipmentRepository) { _shipmentRepository = shipmentRepository; }
        public async Task<bool> Handle(SetStateCommand command, CancellationToken cancellationToken)
        {
            return await _shipmentRepository.SetState(command.ShipmentId, command.State);
        }
    }
}

using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using POST.Core.Abstractions;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class DeleteBoxCommand : IRequest<bool>
    {
        public Guid ShipmentId { get; set; }
        public Guid BoxId { get; set; }
    }
    public class DeleteBoxHandler : IRequestHandler<DeleteBoxCommand, bool>
    {
        private readonly IShipmentRepository _shipmentRepository;
        public DeleteBoxHandler(ShipmentRepository shipmentRepository) { _shipmentRepository = shipmentRepository; }
        public async Task<bool> Handle(DeleteBoxCommand command, CancellationToken cancellationToken)
        {
            return await _shipmentRepository.DeleteBox(command.ShipmentId, command.BoxId);
        }
    }
}

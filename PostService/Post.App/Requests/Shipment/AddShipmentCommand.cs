using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class AddShipmentCommand : IRequest<Guid>
    {
        public string Description { get; set; }
        public Guid SenderId { get; set; }
        public Guid? ReceiverId { get; set; }
        public Guid DepartmentSenderId { get; set; }
        public Guid DestinationId { get; set; }
    }
    public class AddShipmentHandler : IRequestHandler<AddShipmentCommand, Guid> 
    {
        private readonly IShipmentRepository _repository;
        public AddShipmentHandler(ShipmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(AddShipmentCommand command, CancellationToken cancellationToken)
        {
            var shipment = new Shipment
            {
                Description = command.Description,
                SenderId = command.SenderId,
                ReceiverId = command.ReceiverId,
                DepartmentSenderId = command.DepartmentSenderId,
                DestinationId = command.DestinationId,
            };
            return await _repository.Add(shipment);
        }
    }
}

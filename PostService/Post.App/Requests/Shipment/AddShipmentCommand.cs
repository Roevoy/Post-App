using FluentValidation;
using MediatR;
using Post.App.Validators;
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
        private readonly ShipmentValidator _validator;
        public AddShipmentHandler(IShipmentRepository repository, ShipmentValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task<Guid> Handle(AddShipmentCommand command, CancellationToken cancellationToken)
        {
            Shipment shipment;
            if (command.ReceiverId == null)
            {
                shipment = Shipment.FactoryMethod(command.Description, command.SenderId, command.DepartmentSenderId, 
                    command.DestinationId);
            }
            else
            {
                shipment = Shipment.FactoryMethod(command.Description, command.SenderId, command.DepartmentSenderId,
                                    command.DestinationId, (Guid)command.ReceiverId);
            }
                await _validator.ValidateAndThrowAsync(shipment, cancellationToken);   
            return await _repository.Add(shipment);
        }
    }
}

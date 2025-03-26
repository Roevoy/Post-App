using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions;
using Post.Core.Abstractions.Repositories;
using POST.Core.Abstractions;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class AddBoxCommand : IRequest<bool>
    {
        public Guid ShipmentId { get; set; }
        public Size BoxSize { get; set; }
        public string BoxDescription { get; set; }
        public double BoxWeight { get; set; }
    }
    public class AddBoxHandler : IRequestHandler<AddBoxCommand, bool>
    {
        private readonly IShipmentRepository _shipmentRepository;
        public AddBoxHandler(ShipmentRepository shipmentRepository) { _shipmentRepository = shipmentRepository; }
        public async Task<bool> Handle(AddBoxCommand command, CancellationToken cancellationToken)
        {
            var box = new Box
            {
                ShipmentId = command.ShipmentId,
                Description = command.BoxDescription,
                Weight = command.BoxWeight,
                Size = command.BoxSize
            };
            return await _shipmentRepository.AddBox(command.ShipmentId, box);
        }
    }
}

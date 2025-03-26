using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;

namespace Post.App.Requests
{
    public class DeleteShipmentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
    public class DeleteShipmentHandler : IRequestHandler<DeleteShipmentCommand, bool> 
    {
        private readonly IShipmentRepository _repository;
        public DeleteShipmentHandler(ShipmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteShipmentCommand command, CancellationToken cancellationToken)
        {
            return await _repository.DeleteById(command.Id);
        }
    }
}

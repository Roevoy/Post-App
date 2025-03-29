using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class GetShipmentByIdQuery : IRequest<Shipment>
    {
        public Guid Id { get; set; }
    }
    public class GetShipmentByIdHandler : IRequestHandler<GetShipmentByIdQuery, Shipment> 
    {
        private readonly IShipmentRepository _repository;
        public GetShipmentByIdHandler(IShipmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Shipment> Handle(GetShipmentByIdQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetById(query.Id);
        }
    }
}

using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class GetAllShipmentsQuery : IRequest<ICollection<Shipment>>
    {
    }
    public class GetAllShipmentsHandler : IRequestHandler<GetAllShipmentsQuery, ICollection<Shipment>> 
    {
        private readonly IShipmentRepository _repository;
        public GetAllShipmentsHandler(IShipmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICollection<Shipment>> Handle(GetAllShipmentsQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }
    }
}

using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class GetAllBoxesQuery : IRequest<ICollection<Box>>
    {
        public Guid ShipmentId { get; set; }
    }
    public class GetAllBoxesHandler : IRequestHandler<GetAllBoxesQuery, ICollection<Box>>
    {
        private readonly IShipmentRepository _shipmentRepository;
        public GetAllBoxesHandler(IShipmentRepository shipmentRepository) { _shipmentRepository = shipmentRepository; }
        public async Task<ICollection<Box>> Handle(GetAllBoxesQuery query, CancellationToken cancellationToken)
        {
            return await _shipmentRepository.GetAllBoxex(query.ShipmentId, cancellationToken);
        }
    }
}

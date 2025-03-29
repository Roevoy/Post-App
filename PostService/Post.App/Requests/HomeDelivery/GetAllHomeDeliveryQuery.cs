using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using Post.Core.Models;

namespace Post.App.Requests
{
    public class GetAllHomeDeliveryQuery : IRequest<ICollection<HomeDelivery>> { }
    public class GetAllHomeDeliveryHandler : IRequestHandler<GetAllHomeDeliveryQuery, ICollection<HomeDelivery>>
    {
        private readonly IHomeDeliveryRepository _repository;
        public GetAllHomeDeliveryHandler(IHomeDeliveryRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICollection<HomeDelivery>> Handle(GetAllHomeDeliveryQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }
    }
}

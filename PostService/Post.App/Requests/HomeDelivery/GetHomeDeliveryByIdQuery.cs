using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using Post.Core.Models;

namespace Post.App.Requests
{
    public class GetHomeDeliveryByIdQuery : IRequest<HomeDelivery>
    {
        public Guid Id { get; set; }
    }
    public class GetHomeDeliveryByIdHandler : IRequestHandler<GetHomeDeliveryByIdQuery, HomeDelivery>
    {
        private readonly IHomeDeliveryRepository _repository;
        public GetHomeDeliveryByIdHandler(IHomeDeliveryRepository repository) { _repository = repository; }
        public async Task<HomeDelivery> Handle (GetHomeDeliveryByIdQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetById(query.Id);
        }

    }
}

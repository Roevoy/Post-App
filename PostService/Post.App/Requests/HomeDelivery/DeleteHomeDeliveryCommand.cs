using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;

namespace Post.App.Requests
{
    public class DeleteHomeDeliveryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
    public class DeleteHomeDeliveryHandler : IRequestHandler<DeleteHomeDeliveryCommand, bool>
    {
        private readonly IHomeDeliveryRepository _repository;
        public DeleteHomeDeliveryHandler(IHomeDeliveryRepository repository) { _repository = repository; }
        public async Task<bool> Handle(DeleteHomeDeliveryCommand command, CancellationToken cancellationToken)
        {
            return await _repository.DeleteById(command.Id);
        }
    }
}

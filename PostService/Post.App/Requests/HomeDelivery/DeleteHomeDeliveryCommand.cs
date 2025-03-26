using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Post.App.Requests
{
    public class DeleteHomeDeliveryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
    public class DeleteHomeDeliveryHandler : IRequestHandler<DeleteHomeDeliveryCommand, bool>
    {
        private readonly IHomeDeliveryRepository _repository;
        public DeleteHomeDeliveryHandler(HomeDeliveryRepository repository) { _repository = repository; }
        public async Task<bool> Handle(DeleteHomeDeliveryCommand command, CancellationToken cancellationToken)
        {
            return await _repository.DeleteById(command.Id);
        }
    }
}

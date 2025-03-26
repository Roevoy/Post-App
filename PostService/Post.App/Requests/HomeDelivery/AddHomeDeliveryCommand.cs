using MediatR;
using Post.Core.Abstractions.Repositories;
using Post.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.App.Requests
{
    public class AddHomeDeliveryCommand : IRequest<Guid>
    {
        public Guid addressId { get; set; }
        public Guid recipientId { get; set; }
    }
    public class AddHomeDeliveryHandler : IRequestHandler<AddHomeDeliveryCommand, Guid>
    {
        private readonly IHomeDeliveryRepository _repository;
        public AddHomeDeliveryHandler(IHomeDeliveryRepository repository) { _repository = repository; }
        public async Task<Guid> Handle(AddHomeDeliveryCommand command, CancellationToken cancellationToken)
        {
            var homeDelivery = new HomeDelivery
            {
                AddressId = command.addressId,
                RecipientId = command.recipientId
            };
            return await _repository.Add(homeDelivery);
        }
    }
}

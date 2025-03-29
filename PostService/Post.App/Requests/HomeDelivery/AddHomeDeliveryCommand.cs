using FluentValidation;
using MediatR;
using Post.App.Validators;
using Post.Core.Abstractions.Repositories;
using Post.Core.Models;


namespace Post.App.Requests
{
    public class AddHomeDeliveryCommand : IRequest<Guid>
    {
        public Guid addressId { get; set; }
        public Guid recipientId { get; set; }
    }
    public class AddHomeDeliveryHandler : IRequestHandler<AddHomeDeliveryCommand, Guid>
    {
        private readonly HttpClient _httpClient;
        private readonly IHomeDeliveryRepository _repository;
        private readonly HomeDeliveryValidator _validator;
        public AddHomeDeliveryHandler(IHomeDeliveryRepository repository, HomeDeliveryValidator validator, HttpClient httpClient)
        {
            _repository = repository;
            _validator = validator;
            _httpClient = httpClient;
        }
        public async Task<Guid> Handle(AddHomeDeliveryCommand command, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5001/api/Client/GetClient?Id={command.recipientId}");
            response.EnsureSuccessStatusCode();
            var homeDelivery = HomeDelivery.FactoryMethod(command.recipientId, command.addressId);
            await _validator.ValidateAndThrowAsync(homeDelivery, cancellationToken);    
            return await _repository.Add(homeDelivery);
        }
    }
}

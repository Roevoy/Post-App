using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class AddAddressCommand : IRequest<Guid>
    {
        public string Region { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }
    public class AddAddressHandler : IRequestHandler<AddAddressCommand, Guid>
    {
        private readonly IAddressRepository _addressRepository;
        public AddAddressHandler(AddressRepository addressRepository)
        { 
            _addressRepository = addressRepository;
        }
        public async Task<Guid> Handle (AddAddressCommand command, CancellationToken cancellationToken)
        {
            var address = new Address
            {
                Region = command.Region,
                Country = command.Country,
                City = command.City,
                Street = command.Street,
                Number = command.Number,
            };
            await _addressRepository.Add(address);
            return address.Id;
        }
    }
}

using FluentValidation;
using MediatR;
using Post.App.Validators;
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
        private readonly AddressValidator _addressValidator;
        public AddAddressHandler(IAddressRepository addressRepository, AddressValidator addressValidator)
        { 
            _addressRepository = addressRepository;
            _addressValidator = addressValidator;
        }
        public async Task<Guid> Handle (AddAddressCommand command, CancellationToken cancellationToken)
        {
            var address = Address.FactoryMethod(command.Region, command.Country, command.City, command.Street,  command.Number);
            await _addressValidator.ValidateAndThrowAsync(address, cancellationToken);
            await _addressRepository.Add(address);
            return address.Id;
        }
    }
}

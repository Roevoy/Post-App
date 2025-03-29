using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;


namespace Post.App.Requests
{
    public class GetAddressByIdQuery : IRequest<Address>
    {
        public Guid Id { get; set; }
    }
    public class GetAddressByIdHandler : IRequestHandler<GetAddressByIdQuery, Address>
    { 
        private readonly IAddressRepository _addressRepository;
        public GetAddressByIdHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<Address> Handle(GetAddressByIdQuery query, CancellationToken cancellationToken)
        {
            return await _addressRepository.GetById(query.Id);
        }
    }

}

using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class GetAllAddressesQuery : IRequest<ICollection<Address>>
    {
    }
    public class GetGetAllAddressesHandler : IRequestHandler<GetAllAddressesQuery, ICollection<Address>>
    {
        private readonly IAddressRepository _addressRepository;
        public GetGetAllAddressesHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<ICollection<Address>> Handle(GetAllAddressesQuery query, CancellationToken cancellationToken)
        {
            return await _addressRepository.GetAll(cancellationToken);
        }
    }
}

using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;

namespace Post.App.Requests
{
    public class DeleteAddressCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
    public class DeleteAddressHandler : IRequestHandler<DeleteAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;
        public DeleteAddressHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<bool> Handle(DeleteAddressCommand command, CancellationToken cancellationToken)
        {
            return await _addressRepository.Delete(command.Id);
        }
    }
}

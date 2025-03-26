using POST.Core.Models;

namespace Post.Core.Abstractions.Repositories
{
    public interface IAddressRepository
    {
        public Task<Guid> Add(Address address);
        public Task<Address> GetById(Guid id);
        public Task<ICollection<Address>> GetAll(CancellationToken cancellationToken);
        public Task<bool> Delete(Guid id);
    }
}

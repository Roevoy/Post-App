using Post.Core.Models;

namespace Post.Core.Abstractions.Repositories
{
    public interface IHomeDeliveryRepository
    {
        public Task<Guid> Add(HomeDelivery homeDelivery);
        public Task<HomeDelivery> GetById(Guid id);
        public Task<ICollection<HomeDelivery>> GetAll(CancellationToken cancellationToken);
        public Task<bool> DeleteById(Guid id);
    }
}

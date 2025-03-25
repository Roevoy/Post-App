using POST.Core.Models;

namespace Post.Core.Abstractions.Repositories
{
    public interface IShipmentRepository
    {
        public Task<Guid> Add(Shipment shipment);
        public Task<Shipment> GetById(Guid id);
        public Task<ICollection<Shipment>> GetAll(CancellationToken cancellationToken);
        public Task<bool> DeleteById(Guid id);
        public Task<bool> AddBox(Guid shipmentId, Box box);
        public Task<bool> DeleteBox(Guid shipmentId, Guid boxId);
        public Task<ICollection<Box>> GetAllBoxex(Guid shipmentId, CancellationToken cancellationToken);
        public Task<bool> SetState(Guid id, State state);
    }
}

using POST.Core.Models;

namespace Post.Core.Abstractions.Repositories
{
    public interface IParcelLockerRepository
    {
        public Task<Guid> Add(ParcelLocker parcelLocker);
        public Task<ParcelLocker> GetById(Guid id);
        public Task<ICollection<ParcelLocker>> GetAll(CancellationToken cancellationToken);
        public Task<bool> DeleteById(Guid id);
        public Task<ICollection<Slot>> GetAllSlots(Guid parcelLockerId);
    }
}

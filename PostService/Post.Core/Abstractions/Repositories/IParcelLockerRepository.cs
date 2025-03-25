using Post.Core.Models;
using POST.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using Microsoft.EntityFrameworkCore;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;
using POST.DAL;


namespace Post.App.Repositories
{
    public class ParcelLockerRepository : IParcelLockerRepository
    {
        private readonly PostDbContext _dbContext;
        public ParcelLockerRepository(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Add(ParcelLocker parcelLocker)
        {
            await _dbContext.Destinations.AddAsync(parcelLocker);
            await _dbContext.SaveChangesAsync();
            return parcelLocker.Id;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var parcelLocker = await GetById(id);
            _dbContext.Destinations.Remove(parcelLocker);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<ParcelLocker>> GetAll(CancellationToken cancellationToken)
        {
            return await _dbContext.Destinations.OfType<ParcelLocker>().ToListAsync(cancellationToken);
        }

        public async Task<ParcelLocker> GetById(Guid id)
        {
            var parcelLocker = await _dbContext.Destinations
                .OfType<ParcelLocker>()
                .Include(pl => pl.Slots)
                .FirstOrDefaultAsync(pl => pl.Id == id);
            if (parcelLocker == null) { throw new KeyNotFoundException($"The parcel locker with ID {id} is not found."); }
            return parcelLocker;
        }
        public async Task<ICollection<Slot>> GetAllSlots(Guid parcelLockerId)
        {
            var parcelLocker = await GetById(parcelLockerId);
            return parcelLocker.Slots.ToList();
        }
        public async Task<Guid> AddSlot (Slot slot, Guid parcelLockerId)
        {
            var parcelLocker = await GetById (parcelLockerId);
            var entry = _dbContext.Entry(parcelLocker);
            if (entry.State == EntityState.Detached)
            {
                _dbContext.Attach(parcelLocker);
            }
            parcelLocker.Slots.Add(slot);
            _dbContext.Entry(slot).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return slot.Id;
        }
    }
}

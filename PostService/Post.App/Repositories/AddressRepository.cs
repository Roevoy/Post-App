using Microsoft.EntityFrameworkCore;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;
using POST.DAL;

namespace Post.App.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly PostDbContext _dbContext;
        public AddressRepository(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Add(Address address)
        {
            await _dbContext.Addresses.AddAsync(address);
            await _dbContext.SaveChangesAsync();
            return address.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var address = await GetById(id);
            _dbContext.Addresses.Remove(address);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Address>> GetAll(CancellationToken cancellationToken)
        {
            return await _dbContext.Addresses.ToListAsync(cancellationToken);
        }

        public async Task<Address> GetById(Guid id)
        {
            var address = await _dbContext.Addresses.FindAsync(id);
            if (address == null) {throw new KeyNotFoundException($"The address with ID {id} is not found.");}
            return address;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Post.Core.Abstractions.Repositories;
using Post.Core.Models;
using POST.Core.Models;
using POST.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.App.Repositories
{
    public class HomeDeliveryRepository : IHomeDeliveryRepository
    {
        private readonly PostDbContext _postDbContext;
        public HomeDeliveryRepository(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
        }
        public async Task<Guid> Add(HomeDelivery homeDelivery)
        {
            await _postDbContext.AddAsync(homeDelivery);
            await _postDbContext.SaveChangesAsync();
            return homeDelivery.Id;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var delivery = await GetById(id);
            _postDbContext.Destinations.Remove(delivery);
            await _postDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<HomeDelivery>> GetAll(CancellationToken cancellationToken)
        {
            return await _postDbContext.Destinations.OfType<HomeDelivery>().ToListAsync(cancellationToken);
        }

        public async Task<HomeDelivery> GetById(Guid id)
        {
            var homeDelivery = await _postDbContext.Destinations.OfType<HomeDelivery>().FirstOrDefaultAsync(e => e.Id == id);
            if (homeDelivery == null) { throw new KeyNotFoundException($"Home delivery with ID {id} is not found."); }
            return homeDelivery;
        }
    }
}

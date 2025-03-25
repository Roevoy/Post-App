using Post.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

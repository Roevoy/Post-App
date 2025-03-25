using POST.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

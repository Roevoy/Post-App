using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Core.Models;

namespace User.Core.Abstractions.Repositories
{
    public interface IClientRepository
    {
        public Task Add(Client client);
        public Task<Client> GetById(Guid id);
        public Task<List<Client>> GetAll(CancellationToken cancellationToken);
        public Task Delete(Guid id);
    }
}

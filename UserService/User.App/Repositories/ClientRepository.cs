using Microsoft.EntityFrameworkCore;
using User.Core.Abstractions.Repositories;
using User.Core.Models;
using User.DAL;

namespace User.App.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly UserDbContext _userDbContext;
        public ClientRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public async Task Add(Client client)
        {
            await _userDbContext.Clients.AddAsync(client);
            await _userDbContext.SaveChangesAsync();
        }
        public async Task<Client> GetById(Guid id)
        {
            var client = await _userDbContext.Clients.FindAsync(id);
            if (client == null) { throw new KeyNotFoundException($"Client {id} is not found."); }
            return client;
        }
        public async Task<List<Client>> GetAll(CancellationToken cancellationToken)
        {
            return await _userDbContext.Clients.ToListAsync(cancellationToken); 
        }
        public async Task Delete(Guid id)
        {
            var client = await GetById(id);
            _userDbContext.Clients.Remove(client);
            await _userDbContext.SaveChangesAsync();
        }
       
    }
}

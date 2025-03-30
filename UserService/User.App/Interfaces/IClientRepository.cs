using User.Core.Models;

namespace User.App.Interfaces
{
    public interface IClientRepository
    {
        public Task Add(Client client);
        public Task<Client> GetById(Guid id);
        public Task<Client> GetByEmail(string Email);
        public Task<List<Client>> GetAll(CancellationToken cancellationToken);
        public Task Delete(Guid id);
    }
}

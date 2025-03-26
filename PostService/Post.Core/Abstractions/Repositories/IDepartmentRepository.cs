using POST.Core.Models;
namespace Post.Core.Abstractions.Repositories
{
    public interface IDepartmentRepository
    {
        public Task<Guid> Add(Department department);
        public Task<Department> GetById(Guid id);
        public Task<ICollection<Department>> GetAll(CancellationToken cancellationToken);
        public Task<bool> Delete(Guid id);
    }
}

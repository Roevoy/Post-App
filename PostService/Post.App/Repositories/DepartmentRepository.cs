using Microsoft.EntityFrameworkCore;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;
using POST.DAL;

namespace Post.App.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly PostDbContext _dbContext;
        public DepartmentRepository(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Add(Department department)
        {
            _dbContext.Destinations.Add(department);
            await _dbContext.SaveChangesAsync();
            return department.Id;
        }
        public async Task<bool> Delete(Guid id)
        {
            var department = await GetById(id);
            _dbContext.Destinations.Remove(department);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<ICollection<Department>> GetAll(CancellationToken cancellationToken)
        {
            return await _dbContext.Destinations.OfType<Department>().ToListAsync(cancellationToken);
        }
        public async Task<Department> GetById(Guid id)
        {
            var department = await _dbContext.Destinations.OfType<Department>().FirstOrDefaultAsync(d => d.Id == id);
            if (department == null) { throw new KeyNotFoundException($"The department with ID {id} is not found."); }
            return department;
        }
    }
}

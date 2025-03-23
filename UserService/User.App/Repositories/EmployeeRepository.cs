using Microsoft.EntityFrameworkCore;
using User.Core.Abstractions.Repositories;
using User.Core.Models;
using User.DAL;

namespace User.App.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly UserDbContext _userDbContext;
        public EmployeeRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public async Task Add(Employee Employee)
        {
            await _userDbContext.Employees.AddAsync(Employee);
            await _userDbContext.SaveChangesAsync();
        }
        public async Task<Employee> GetById (Guid id)
        {
            var Employee = await _userDbContext.Employees.FindAsync(id);
            if (Employee == null) { throw new KeyNotFoundException($"Employee {id} is not found."); }
            return Employee;
        }
        public async Task<List<Employee>> GetAll(CancellationToken cancellation)
        {
            return await _userDbContext.Employees.ToListAsync(cancellation);
        }

        public async Task Delete(Guid id)
        {
            var Employee = await GetById(id);
            _userDbContext.Employees.Remove(Employee);
            await _userDbContext.SaveChangesAsync();
        }
    }
}


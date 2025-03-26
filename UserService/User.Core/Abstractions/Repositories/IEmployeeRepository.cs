using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Core.Models;

namespace User.Core.Abstractions.Repositories
{
    public interface IEmployeeRepository
    {
        public Task Add (Employee employee);
        public Task<Employee> GetById (Guid employee);
        public Task<List<Employee>> GetAll (CancellationToken cancellationToken);
        public Task Delete(Guid id);
        public Task<bool> SetDepartmentId (Guid employeeId, Guid departmentId);
    }
}

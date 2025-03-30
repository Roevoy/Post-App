using User.Core.Models;

namespace User.App.Interfaces
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

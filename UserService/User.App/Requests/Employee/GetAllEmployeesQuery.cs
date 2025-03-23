using MediatR;
using User.Core.Abstractions.Repositories;
using User.Core.Models;

namespace User.App.Requests
{
    public class GetAllEmployeesQuery : IRequest<List<Employee>>
    { }
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, List<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetAllEmployeesHandler(IEmployeeRepository EmployeeRepository)
        {
            _employeeRepository = EmployeeRepository;
        }
        public async Task<List<Employee>> Handle(GetAllEmployeesQuery query, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetAll(cancellationToken);
        }
    }
}

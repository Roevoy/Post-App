using MediatR;
using User.App.Interfaces;
using User.Core.Models;

namespace User.App.Requests
{
    public class GetAllEmployeesQuery : IRequest<List<User.Core.Models.Employee>>
    { }
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, List<User.Core.Models.Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetAllEmployeesHandler(IEmployeeRepository EmployeeRepository)
        {
            _employeeRepository = EmployeeRepository;
        }
        public async Task<List<User.Core.Models.Employee>> Handle(GetAllEmployeesQuery query, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetAll(cancellationToken);
        }
    }
}

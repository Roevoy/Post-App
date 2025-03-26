using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Core.Abstractions.Repositories;

namespace User.App.Requests.Employee
{
    public class SetDepartmentIdCommand : IRequest<bool>
    {
        public Guid EmployeeId { get; set; }
        public Guid DepartmentId { get; set; }
    }
    public class SetDepartmentHandler : IRequestHandler<SetDepartmentIdCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public SetDepartmentHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle (SetDepartmentIdCommand command, CancellationToken cancellationToken)
        {
            return await _employeeRepository.SetDepartmentId(command.EmployeeId, command.DepartmentId);
        }
    }
}

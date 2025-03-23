using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Core.Abstractions.Repositories;
using User.Core.Models;

namespace User.App.Requests
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public Guid Id { get; set; }
    }
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetEmployeeByIdHandler(IEmployeeRepository EmployeeRepository)
        {
            _employeeRepository = EmployeeRepository;
        }
        public async Task<Employee> Handle (GetEmployeeByIdQuery query, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetById(query.Id);
        }
    }
}

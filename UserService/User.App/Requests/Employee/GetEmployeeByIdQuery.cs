using MediatR;
using User.Core.Abstractions.Repositories;
using User.Core.Models;

namespace User.App.Requests
{
    public class GetEmployeeByIdQuery : IRequest<User.Core.Models.Employee>
    {
        public Guid Id { get; set; }
    }
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, User.Core.Models.Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetEmployeeByIdHandler(IEmployeeRepository EmployeeRepository)
        {
            _employeeRepository = EmployeeRepository;
        }
        public async Task<User.Core.Models.Employee> Handle (GetEmployeeByIdQuery query, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetById(query.Id);
        }
    }
}

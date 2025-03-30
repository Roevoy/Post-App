using MediatR;
using User.App.Interfaces;

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
        private readonly HttpClient _httpClient;
        public SetDepartmentHandler(IEmployeeRepository employeeRepository, HttpClient httpClient)
        {
            _employeeRepository = employeeRepository;
            _httpClient = httpClient;
        }

        public async Task<bool> Handle (SetDepartmentIdCommand command, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5002/Post/api/Department/GetDepartmentById?Id={command.DepartmentId}");
            response.EnsureSuccessStatusCode();
            return await _employeeRepository.SetDepartmentId(command.EmployeeId, command.DepartmentId);
        }
    }
}

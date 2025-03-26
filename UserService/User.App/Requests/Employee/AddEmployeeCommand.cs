using MediatR;
using User.Core.Abstractions.Repositories;
using User.Core.Models;
namespace User.App.Requests
{
    public class AddEmployeeCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string? ThirdName { get; set; }
        public int Age { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, Guid>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public AddEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Guid> Handle(AddEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = new User.Core.Models.Employee //replace on factory
            {
                FirstName = command.FirstName,
                SecondName = command.SecondName,
                ThirdName = command.ThirdName,
                Age = command.Age,
                Birthday = command.Birthday,
                Email = command.Email,
                Phone = command.Phone
            };
            await _employeeRepository.Add(employee);
            return employee.Id;
    }
    }
}

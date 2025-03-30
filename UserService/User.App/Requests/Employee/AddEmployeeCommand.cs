using FluentValidation;
using MediatR;
using User.App.Validators;
using User.App.Interfaces;
namespace User.App.Requests
{
    public class AddEmployeeCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string? ThirdName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, Guid>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeValidator _employeeValidator;
        public AddEmployeeHandler(IEmployeeRepository employeeRepository, EmployeeValidator employeeValidator)
        {
            _employeeRepository = employeeRepository;
            _employeeValidator = employeeValidator;
        }
        public async Task<Guid> Handle(AddEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = Core.Models.Employee.FacroryMethod(command.FirstName, command.SecondName, command.Email,
                command.Phone, command.Birthday, command.ThirdName);
            await _employeeValidator.ValidateAndThrowAsync(employee, cancellationToken);
            await _employeeRepository.Add(employee);
            return employee.Id;
        }
    }
}

using MediatR;
using User.App.Interfaces;

namespace User.App.Requests
{
    public class DeleteEmployeeCommand: IRequest<bool>
    {
        public Guid Id { get; set; }
    }
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public DeleteEmployeeHandler(IEmployeeRepository _employeeRepository)
        {
            this._employeeRepository = _employeeRepository;
        }
        public async Task<bool> Handle (DeleteEmployeeCommand command, CancellationToken cancellationToken)
        {
            await _employeeRepository.Delete(command.Id);
            return true;
        }
    }
}

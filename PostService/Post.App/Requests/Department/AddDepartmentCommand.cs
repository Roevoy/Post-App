using MediatR;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class AddDepartmentCommand : IRequest<Guid>
    {
        public int Number { get; set; }
        public Guid AddressId { get; set; }
    }
    public class AddDepartmentHandler : IRequestHandler<AddDepartmentCommand, Guid>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public AddDepartmentHandler(IDepartmentRepository departmentRepository)
        { _departmentRepository = departmentRepository; }
        public async Task<Guid> Handle(AddDepartmentCommand command, CancellationToken cancellationToken)
        {
            var department = new Department
            {
                AddressId = command.AddressId,
                Number = command.Number
            };
            return await _departmentRepository.Add(department);
        }
    }
}

using FluentValidation;
using MediatR;
using Post.App.Validators;
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
        private readonly DepartmentValidator _departmentValidator;
        public AddDepartmentHandler(IDepartmentRepository departmentRepository, DepartmentValidator departmentValidator)
        {
            _departmentRepository = departmentRepository; 
            _departmentValidator = departmentValidator;
        }
        public async Task<Guid> Handle(AddDepartmentCommand command, CancellationToken cancellationToken)
        {
            var department = Department.FactoryMethod(command.Number, command.AddressId);
            await _departmentValidator.ValidateAndThrowAsync(department, cancellationToken);
            return await _departmentRepository.Add(department);
        }
    }
}

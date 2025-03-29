using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class GetDepartmentByIdQuery : IRequest<Department>
    {
        public Guid Id { get; set; }
    }
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, Department>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public GetDepartmentByIdHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<Department> Handle(GetDepartmentByIdQuery query, CancellationToken cancellationToken)
        {
            return await _departmentRepository.GetById(query.Id);
        }
    }
}

using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class GetAllDepartmentsQuery : IRequest<ICollection<Department>> {}
    public class GetAllDepartmentsHandler : IRequestHandler<GetAllDepartmentsQuery, ICollection<Department>> 
    {
        private readonly IDepartmentRepository _repository;
        public GetAllDepartmentsHandler(IDepartmentRepository repository) { _repository = repository; }
        public async Task<ICollection<Department>> Handle(GetAllDepartmentsQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }
    }
}

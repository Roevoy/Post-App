using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Post.App.Requests
{
    public class GetAllDepartmentsQuery : IRequest<ICollection<Department>> {}
    public class GetAllDepartmentsHandler : IRequestHandler<GetAllDepartmentsQuery, ICollection<Department>> 
    {
        private readonly IDepartmentRepository _repository;
        public GetAllDepartmentsHandler(DepartmentRepository repository) { _repository = repository; }
        public async Task<ICollection<Department>> Handle(GetAllDepartmentsQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }
    }
}

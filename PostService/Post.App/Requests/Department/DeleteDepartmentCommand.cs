using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.App.Requests
{
    public class DeleteDepartmentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand, bool>
    {
        private readonly IDepartmentRepository _repository;
        public DeleteDepartmentHandler(DepartmentRepository repository) { _repository = repository; }
        public async Task<bool> Handle (DeleteDepartmentCommand command, CancellationToken cancellationToken)
        {
            return await _repository.Delete(command.Id);
        }
    }
}

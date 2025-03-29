using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class GetParcelLockerByIdQuery : IRequest<ParcelLocker>
    {
        public Guid Id { get; set; }
    }
    public class GetParcelLockerByIdHandler : IRequestHandler<GetParcelLockerByIdQuery, ParcelLocker>
    {
        private readonly IParcelLockerRepository _lockerRepository;
        public GetParcelLockerByIdHandler(IParcelLockerRepository lockerRepository) { _lockerRepository = lockerRepository; }
        public async Task<ParcelLocker> Handle(GetParcelLockerByIdQuery query, CancellationToken cancellationToken)
        {
            return await _lockerRepository.GetById(query.Id);
        }
    }
}

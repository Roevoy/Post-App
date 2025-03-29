using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class GetAllParcelLockersQuery : IRequest<ICollection<ParcelLocker>>
    {

    }
    public class GetAllParcelLokersHandler : IRequestHandler<GetAllParcelLockersQuery, ICollection<ParcelLocker>>
    {
        private readonly IParcelLockerRepository _lockerRepository;
        public GetAllParcelLokersHandler(IParcelLockerRepository lockerRepository) { _lockerRepository = lockerRepository; }
        public async Task<ICollection<ParcelLocker>> Handle(GetAllParcelLockersQuery query, CancellationToken cancellationToken)
        {
            return await _lockerRepository.GetAll(cancellationToken);
        }
    }
}

using MediatR;
using Post.App.Repositories;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class GetAllSlotsQuery : IRequest<ICollection<Slot>>
    {
        public Guid ParcelLockerId { get; set; }
    }
    public class GetAllSlotsHandler : IRequestHandler<GetAllSlotsQuery, ICollection<Slot>>
    {
        private readonly IParcelLockerRepository _lockerRepository;
        public GetAllSlotsHandler (ParcelLockerRepository lockerRepository) { _lockerRepository = lockerRepository; }
        public async Task<ICollection<Slot>> Handle (GetAllSlotsQuery query, CancellationToken cancellationToken)
        {
            return await _lockerRepository.GetAllSlots(query.ParcelLockerId);
        }
    }
}

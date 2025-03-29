using FluentValidation;
using MediatR;
using Post.App.Validators;
using Post.Core.Abstractions.Repositories;
using POST.Core.Abstractions;
using POST.Core.Models;


namespace Post.App.Requests
{
    public class AddSlotCommand : IRequest<bool>
    {
        public Guid ParcelLockerId { get; set; }
        public int Number {  get; set; }
        public Size Size { get; set; }
    }
    public class AddSlotHandler : IRequestHandler<AddSlotCommand, bool>
    {
        private readonly IParcelLockerRepository _parcelLockerRepository;
        private readonly SlotValidator _slotValidator;
        public AddSlotHandler (IParcelLockerRepository parcelLockerRepository, SlotValidator slotValidator)
        {
            _parcelLockerRepository = parcelLockerRepository;
            _slotValidator = slotValidator;
        }
        public async Task<bool> Handle (AddSlotCommand command, CancellationToken cancellationToken)
        {
            var slot = Slot.FactoryMethod(command.Number, command.Size, command.ParcelLockerId);
            await _slotValidator.ValidateAndThrowAsync(slot, cancellationToken);
            await _parcelLockerRepository.AddSlot(slot, command.ParcelLockerId);
            return true;
        }
    }
}

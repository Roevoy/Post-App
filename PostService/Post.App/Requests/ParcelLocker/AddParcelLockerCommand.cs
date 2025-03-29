
using FluentValidation;
using MediatR;
using Post.App.Repositories;
using Post.App.Validators;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class AddParcelLockerCommand : IRequest<Guid>
    {
        public Guid AddressId { get; set; }
    }
    public class AddParcelLockerHandler : IRequestHandler<AddParcelLockerCommand, Guid>
    {
        private readonly IParcelLockerRepository _repository;
        private readonly ParcelLockerValidator _validator;
        public AddParcelLockerHandler(IParcelLockerRepository repository, ParcelLockerValidator validator)
        {
            _validator = validator;
            _repository = repository;
        }
        public async Task<Guid> Handle(AddParcelLockerCommand command, CancellationToken cancellationToken)
        {
            var parrcelLocker = ParcelLocker.FactoryMethod(command.AddressId);
            await _validator.ValidateAndThrowAsync(parrcelLocker, cancellationToken);
            return await _repository.Add(parrcelLocker);
        }
    }
}

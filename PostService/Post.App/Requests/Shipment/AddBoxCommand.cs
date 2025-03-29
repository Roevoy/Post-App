using FluentValidation;
using MediatR;
using Post.App.Repositories;
using Post.App.Validators;
using Post.Core.Abstractions.Repositories;
using POST.Core.Abstractions;
using POST.Core.Models;

namespace Post.App.Requests
{
    public class AddBoxCommand : IRequest<bool>
    {
        public Guid ShipmentId { get; set; }
        public Size BoxSize { get; set; }
        public string BoxDescription { get; set; }
        public double BoxWeight { get; set; }
    }
    public class AddBoxHandler : IRequestHandler<AddBoxCommand, bool>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly BoxValidator _boxValidator;
        public AddBoxHandler(IShipmentRepository shipmentRepository, BoxValidator boxValidator) 
        { 
            _shipmentRepository = shipmentRepository; 
            _boxValidator = boxValidator;
        }
        public async Task<bool> Handle(AddBoxCommand command, CancellationToken cancellationToken)
        {
            var box = Box.FactoryMethod(command.BoxDescription, command.BoxWeight, command.BoxSize, command.ShipmentId);
            await _boxValidator.ValidateAndThrowAsync(box, cancellationToken);
            return await _shipmentRepository.AddBox(command.ShipmentId, box);
        }
    }
}

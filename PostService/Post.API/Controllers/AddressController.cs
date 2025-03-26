using MediatR;
using Microsoft.AspNetCore.Mvc;
using Post.App.Requests;

namespace Post.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddressController(Mediator mediator) { _mediator = mediator; }
        [HttpPost]
        public async Task<IActionResult> AddAddress(AddAddressCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAddress (DeleteAddressCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAddressById (GetAddressByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAddresses ([FromQuery]GetAllAddressesQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    
    }
}

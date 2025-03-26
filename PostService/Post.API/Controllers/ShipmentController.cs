using MediatR;
using Microsoft.AspNetCore.Mvc;
using Post.App.Requests;

namespace Post.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ShipmentController(Mediator mediator) { _mediator = mediator; }
        [HttpPost]
        public async Task<IActionResult> AddShipment(AddShipmentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteShipment(DeleteShipmentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetShipmentById(GetShipmentByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShipmentes([FromQuery] GetAllShipmentsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost]
        public async Task<IActionResult> AddBox(AddBoxCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBoxes(GetAllBoxesQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost]
        public async Task<IActionResult> SetState(SetStateCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBox(DeleteBoxCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}

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
        public ShipmentController(IMediator mediator) { _mediator = mediator; }
        [HttpPost("CreateShipment")]
        public async Task<IActionResult> AddShipment(AddShipmentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete("DeleteShipment")]
        public async Task<IActionResult> DeleteShipment(DeleteShipmentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("GetShipmentById")]
        public async Task<IActionResult> GetShipmentById([FromQuery] GetShipmentByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("GetAllShipments")]
        public async Task<IActionResult> GetAllShipmentes([FromQuery] GetAllShipmentsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost("AddBox")]
        public async Task<IActionResult> AddBox(AddBoxCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("GetAllBoxes")]
        public async Task<IActionResult> GetAllBoxes([FromQuery] GetAllBoxesQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPatch("SetState")]
        public async Task<IActionResult> SetState(SetStateCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}

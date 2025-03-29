using MediatR;
using Microsoft.AspNetCore.Mvc;
using Post.App.Requests;

namespace Post.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelLockerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ParcelLockerController(IMediator mediator) { _mediator = mediator; }
        [HttpPost("AddParcelLocker")]
        public async Task<IActionResult> AddParcelLocker(AddParcelLockerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete("DeleteParcelLocker")]
        public async Task<IActionResult> DeleteParcelLocker(DeleteParcelLockerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("GetParcelLockerById")]
        public async Task<IActionResult> GetParcelLockerById([FromQuery]GetParcelLockerByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("GetAllParcelLockers")]
        public async Task<IActionResult> GetAllParcelLockeres([FromQuery] GetAllParcelLockersQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("GetAllSlots")] 
        public async Task<IActionResult> GetAllSlots ([FromQuery]GetAllSlotsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost("AddSlot")]
        public async Task<IActionResult> AddSlot (AddSlotCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Post.App.Requests;

namespace Post.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelLockerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ParcelLockerController(Mediator mediator) { _mediator = mediator; }
        [HttpPost]
        public async Task<IActionResult> AddParcelLocker(AddParcelLockerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteParcelLocker(DeleteParcelLockerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetParcelLockerById(GetParcelLockerByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllParcelLockeres([FromQuery] GetAllParcelLockersQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet] 
        public async Task<IActionResult> GetAllSlots (GetAllSlotsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}

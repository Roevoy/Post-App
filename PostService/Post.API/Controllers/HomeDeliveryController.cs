using MediatR;
using Microsoft.AspNetCore.Mvc;
using Post.App.Requests;

namespace Post.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeDeliveryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HomeDeliveryController(IMediator mediator) { _mediator = mediator; }
        [HttpPost("CreateHomeDelivery")]
        public async Task<IActionResult> AddHomeDelivery(AddHomeDeliveryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete("DeleteHomeDelivery")]
        public async Task<IActionResult> DeleteHomeDelivery(DeleteHomeDeliveryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("GetHomeDeliveryById")]
        public async Task<IActionResult> GetHomeDeliveryById([FromQuery]GetHomeDeliveryByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("GetAllHomeDeliveries")]
        public async Task<IActionResult> GetAllHomeDeliveryes([FromQuery] GetAllHomeDeliveryQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}

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
        public HomeDeliveryController(Mediator mediator) { _mediator = mediator; }
        [HttpPost]
        public async Task<IActionResult> AddHomeDelivery(AddHomeDeliveryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHomeDelivery(DeleteHomeDeliveryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetHomeDeliveryById(GetHomeDeliveryByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHomeDeliveryes([FromQuery] GetAllHomeDeliveryQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}

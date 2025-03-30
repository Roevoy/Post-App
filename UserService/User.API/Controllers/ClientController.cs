using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.App.Requests;
using User.App.Validators;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;

        public ClientController(IMediator mediator, IHttpContextAccessor contextAccessor)
        {
            _mediator = mediator;
            _contextAccessor = contextAccessor;
        }
        [Authorize]
        [HttpGet("GetClient")]
        public async Task<IActionResult> GetClient([FromQuery] GetClientByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [Authorize]
        [HttpGet("GetAllClients")]
        public async Task<IActionResult> GetAllClients([FromQuery] GetAllClientsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost("AddClient")]
        public async Task<IActionResult> AddClient(AddClientCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [Authorize]
        [HttpDelete("DeleteClient")]
        public async Task<IActionResult> DeleteClient(DeleteClientCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login (LoginClientQuery query)
        {
            var token = await _mediator.Send(query);
            _contextAccessor.HttpContext.Response.Cookies.Append("token", token);
            return Ok(token);
        }

    }
}

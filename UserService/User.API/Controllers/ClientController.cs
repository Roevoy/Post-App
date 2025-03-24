using FluentValidation;
using MediatR;
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

        public ClientController(IMediator mediator) 
        { 
            _mediator = mediator;
        }
        [HttpGet("GetClient")]
        public async Task<IActionResult> GetClient([FromQuery]GetClientByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("GetAllClients")]
        public async Task<IActionResult> GetAllClients ([FromQuery]GetAllClientsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost("AddClient")]
        public async Task<IActionResult> AddClient (AddClientCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete("DeleteClient")]
        public async Task<IActionResult> DeleteClient (DeleteClientCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}

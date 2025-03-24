using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.App.Requests;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployee([FromQuery]GetEmployeeByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees([FromQuery]GetAllEmployeesQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(AddEmployeeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(DeleteEmployeeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}

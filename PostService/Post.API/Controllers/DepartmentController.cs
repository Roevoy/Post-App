﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Post.App.Requests;

namespace Post.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartmentController(IMediator mediator) { _mediator = mediator; }
        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> AddDepartment(AddDepartmentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(DeleteDepartmentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("GetDepartmentById")]
        public async Task<IActionResult> GetDepartmentById([FromQuery]GetDepartmentByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("GetAllDepartments")]
        public async Task<IActionResult> GetAllDepartmentes([FromQuery] GetAllDepartmentsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}

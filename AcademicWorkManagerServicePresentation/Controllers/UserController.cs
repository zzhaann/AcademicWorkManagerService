﻿using AcademicWorkManagerService.Application.UseCases.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademicWorkManagerService.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class UserController(IMediator mediator) : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetUsersQuery());
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetUserByIdQuery(id));
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);

            return Ok(result);
        }
        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var result = await mediator.Send(new GetUserByUsernameQuery(username));
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);
            return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserCommand command)
        {
            var updatedCommand = command with { Id = id };
            var result = await mediator.Send(updatedCommand);
            
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);
            
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new DeleteUserCommand(id));
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);
            return Ok(result);
        }
    }
}

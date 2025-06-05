using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Application.UseCases.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;

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
        public async Task<IActionResult> Post([FromBody] CreateUserQuery command)
        {
            var result = await mediator.Send(command);
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);
            return CreatedAtAction(nameof(GetById), new { id = result.Value.id }, result.Value);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserQuery command)
        {
            if (id != command.Id)
                return BadRequest("User ID mismatch");
            var result = await mediator.Send(command);
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new DeleteUserQuery(id));
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);
            return NoContent();
        }
    }
}

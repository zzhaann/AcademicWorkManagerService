using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.UseCases.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class AuthController(IMediator mediator) : BaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await mediator.Send(command);

            if (result.IsFailed)
            {
                return GenerateProblemResponse(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            var result = await mediator.Send(command);

            if (result.IsFailed)
            {
                return GenerateProblemResponse(result.Error);
            }

            return Ok(result.Value);
        }
    }
}

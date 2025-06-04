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
    }
}

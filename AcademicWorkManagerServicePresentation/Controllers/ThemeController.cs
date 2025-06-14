using AcademicWorkManagerService.Application.UseCases.Theme;
using AcademicWorkManagerService.Application.UseCases.Themes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcademicWorkManagerService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemeController(IMediator mediator) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetThemesQuery());
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetThemeByIdQuery(id));
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateThemeCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);

            return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateThemeCommand command)
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
            var result = await mediator.Send(new DeleteThemeCommand(id));
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);

            return Ok(result);
        }
    }
}

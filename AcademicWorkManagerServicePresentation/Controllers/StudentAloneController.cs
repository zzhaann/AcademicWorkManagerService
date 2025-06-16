using AcademicWorkManagerService.Application.UseCases.StudentAlones;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademicWorkManagerService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAloneController(IMediator mediator) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllStudentAloneQuery());
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);

            return Ok(result);
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetByStudentId(int studentId)
        {
            var result = await mediator.Send(new GetStudentAloneByStudentQuery(studentId));
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStudentAloneCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);

            return Created(string.Empty, result.Value); // можно заменить на CreatedAtAction при наличии GetById
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateStudentAloneCommand command)
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
            var result = await mediator.Send(new DeleteStudentAloneCommand(id));
            if (result.IsFailed)
                return GenerateProblemResponse(result.Error);

            return Ok(result);
        }
    }
}

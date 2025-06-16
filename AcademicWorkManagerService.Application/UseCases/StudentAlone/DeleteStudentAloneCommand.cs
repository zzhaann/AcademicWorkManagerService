using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.StudentAlones
{
    public record DeleteStudentAloneCommand(int Id) : IRequest<Result<bool>>;
}

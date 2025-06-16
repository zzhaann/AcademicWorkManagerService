using AcademicWorkManagerService.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.StudentAlones
{
    public record GetStudentAloneByStudentQuery(int StudentId) : IRequest<Result<StudentAloneDTO?>>;
}

using AcademicWorkManagerService.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.StudentAlones
{
    public class GetAllStudentAloneQuery : IRequest<Result<StudentAloneDTO[]>>
    {
    }
}

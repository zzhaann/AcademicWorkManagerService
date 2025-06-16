using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.StudentAlones
{
    public class GetStudentAloneByStudentQueryHandler(IStudentAloneService service): IRequestHandler<GetStudentAloneByStudentQuery, Result<StudentAloneDTO?>>
    {
        public async Task<Result<StudentAloneDTO?>> Handle(GetStudentAloneByStudentQuery request, CancellationToken cancellationToken)
        {
            var result = await service.GetByStudentAsync(request.StudentId);

            if (result.IsFailed)
                return Result.Failure<StudentAloneDTO?>(result.Error);

            return result;
        }
    }
}

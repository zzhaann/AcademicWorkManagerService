using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.StudentAlones
{
    public class CreateStudentAloneCommandHandler(IStudentAloneService service): IRequestHandler<CreateStudentAloneCommand, Result<StudentAloneDTO>>
    {
        public async Task<Result<StudentAloneDTO>> Handle(CreateStudentAloneCommand request, CancellationToken cancellationToken)
        {
            var result = await service.CreateAsync(request.StudentId, request.ThemeId);

            if (result.IsFailed)
                return Result.Failure<StudentAloneDTO>(result.Error);

            return result;
        }
    }
}

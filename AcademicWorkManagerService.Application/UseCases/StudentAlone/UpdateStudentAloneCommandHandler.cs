using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.StudentAlones
{
    public class UpdateStudentAloneCommandHandler(IStudentAloneService service): IRequestHandler<UpdateStudentAloneCommand, Result<StudentAloneDTO>>
    {
        public async Task<Result<StudentAloneDTO>> Handle(UpdateStudentAloneCommand request, CancellationToken cancellationToken)
        {
            var result = await service.UpdateAsync(request.Id, request.ThemeId);

            if (result.IsFailed)
                return Result.Failure<StudentAloneDTO>(result.Error);

            return result;
        }
    }
}

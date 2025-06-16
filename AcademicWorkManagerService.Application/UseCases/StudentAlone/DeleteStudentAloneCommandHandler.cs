using AcademicWorkManagerService.Application.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.StudentAlones
{
    public class DeleteStudentAloneCommandHandler(IStudentAloneService service): IRequestHandler<DeleteStudentAloneCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteStudentAloneCommand request, CancellationToken cancellationToken)
        {
            var result = await service.DeleteAsync(request.Id);

            if (result.IsFailed)
                return Result.Failure<bool>(result.Error);

            return result;
        }
    }
}

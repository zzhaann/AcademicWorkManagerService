using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Domain.Constants;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.StudentAlones
{
    public class GetAllStudentAloneQueryHandler(IStudentAloneService service): IRequestHandler<GetAllStudentAloneQuery, Result<StudentAloneDTO[]>>
    {
        public async Task<Result<StudentAloneDTO[]>> Handle(GetAllStudentAloneQuery request, CancellationToken cancellationToken)
        {
            var result = await service.GetAllAsync();

            if (result.IsFailed)
                return Result.Failure<StudentAloneDTO[]>(new Error(ErrorCode.NotFound, "Нет заявок."));

            return result;
        }
    }
}

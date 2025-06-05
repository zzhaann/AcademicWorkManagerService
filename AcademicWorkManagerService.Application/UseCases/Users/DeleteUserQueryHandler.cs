using AcademicWorkManagerService.Application.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public class DeleteUserQueryHandler(IUserService userService)
        : IRequestHandler<DeleteUserQuery, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteUserQuery request, CancellationToken cancellationToken)
        {
            var result = await userService.DeleteAsync(request.Id);

            if (result.IsFailed)
                return Result.Failure<bool>(result.Error);

            return result;
        }
    }
}

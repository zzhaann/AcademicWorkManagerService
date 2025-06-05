using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Domain.Constants;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public class GetUserByUsernameQueryHandler(IUserService userService)
        : IRequestHandler<GetUserByUsernameQuery, Result<UserDTO?>>
    {
        public async Task<Result<UserDTO?>> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await userService.GetByUsernameAsync(request.Username);

            if (user.IsFailed)
                return Result.Failure<UserDTO?>(user.Error);

            return user;
        }
    }
}

using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public class UpdateUserQueryHandler(IUserService userService)
        : IRequestHandler<UpdateUserQuery, Result<UserDTO>>
    {
        public async Task<Result<UserDTO>> Handle(UpdateUserQuery request, CancellationToken cancellationToken)
        {
            var userDto = new UserDTO
            {
                id = request.Id,
                userName = request.UserName,
                userRole = request.UserRole
            };

            var result = await userService.UpdateAsync(request.Id, userDto);

            if (result.IsFailed)
                return Result.Failure<UserDTO>(result.Error);

            return result;
        }
    }
}

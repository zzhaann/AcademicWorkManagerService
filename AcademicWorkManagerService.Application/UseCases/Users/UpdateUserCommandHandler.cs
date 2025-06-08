using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public class UpdateUserCommandHandler(IUserService userService)
        : IRequestHandler<UpdateUserCommand, Result<UserDTO>>
    {
        public async Task<Result<UserDTO>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
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

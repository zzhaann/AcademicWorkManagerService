using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public class CreateUserCommandHandler(IUserService userService)
        : IRequestHandler<CreateUserCommand, Result<UserDTO>>
    {
        public async Task<Result<UserDTO>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = new UserDTO
            {
                UserName = request.UserName,
                UserRole = request.UserRole
            };

            var result = await userService.CreateAsync(userDto);

            if (result.IsFailed)
                return Result.Failure<UserDTO>(result.Error);

            return result;
        }
    }
}

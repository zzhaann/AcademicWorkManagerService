using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public class CreateUserQueryHandler(IUserService userService)
        : IRequestHandler<CreateUserQuery, Result<UserDTO>>
    {
        public async Task<Result<UserDTO>> Handle(CreateUserQuery request, CancellationToken cancellationToken)
        {
            var userDto = new UserDTO
            {
                userName = request.UserName,
                userRole = request.UserRole
            };

            var result = await userService.CreateAsync(userDto);

            if (result.IsFailed)
                return Result.Failure<UserDTO>(result.Error);

            return result;
        }
    }
}

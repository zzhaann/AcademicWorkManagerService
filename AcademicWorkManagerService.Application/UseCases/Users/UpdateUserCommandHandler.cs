using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<UserDTO>>
    {
        private readonly IUserService userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<Result<UserDTO>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = new UserDTO
            {
                Id = request.Id,
                UserName = request.UserName,
                RoleId = request.RoleId,
                RoleName = request.RoleName
            };

            var result = await userService.UpdateAsync(request.Id, userDto);

            if (result.IsFailed)
                return Result.Failure<UserDTO>(result.Error);

            return result;
        }
    }
}

using AcademicWorkManagerService.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public record UpdateUserCommand : IRequest<Result<UserDTO>>
    {
        public int Id { get; init; }
        public string UserName { get; init; } = null!;
        public int RoleId { get; init; }
        public string RoleName { get; init; } = null!;
    }
}

using AcademicWorkManagerService.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public record GetUserByIdQuery(int Id) : IRequest<Result<UserDTO?>>;
}

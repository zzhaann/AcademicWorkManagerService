using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public record DeleteUserCommand(int Id) : IRequest<Result<bool>>;
}

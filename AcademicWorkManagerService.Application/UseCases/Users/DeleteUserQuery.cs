using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public record DeleteUserQuery(int Id) : IRequest<Result<bool>>;
}

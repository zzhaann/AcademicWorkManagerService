using AcademicWorkManagerService.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.Themes
{
    public record GetThemeByIdQuery(int Id) : IRequest<Result<ThemeDTO?>>;
}

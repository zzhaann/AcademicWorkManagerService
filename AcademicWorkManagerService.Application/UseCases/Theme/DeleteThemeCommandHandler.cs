using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Application.UseCases.Theme;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.Themes
{
    public class DeleteThemeCommandHandler(IThemeService themeService) : IRequestHandler<DeleteThemeCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteThemeCommand request, CancellationToken cancellationToken)
        {
            var result = await themeService.DeleteAsync(request.id);

            if (result.IsFailed)
                return Result.Failure<bool>(result.Error);

            return result;
        }
    }
}

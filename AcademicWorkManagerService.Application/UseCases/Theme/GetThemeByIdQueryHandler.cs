using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.Themes
{
    public class GetThemeByIdQueryHandler(IThemeService themeService) : IRequestHandler<GetThemeByIdQuery, Result<ThemeDTO?>>
    {
        public async Task<Result<ThemeDTO?>> Handle(GetThemeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await themeService.GetByIdAsync(request.Id);

            if(result.IsFailed)
                if (result.IsFailed)
                    return Result.Failure<ThemeDTO?>(result.Error);
            return result;
        }
    }
}

using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Application.UseCases.Theme;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.Themes
{
    public class CreateThemeCommandHandler(IThemeService themeService): IRequestHandler<CreateThemeCommand, Result<ThemeDTO>>
    {
        public async Task<Result<ThemeDTO>> Handle(CreateThemeCommand request, CancellationToken cancellationToken)
        {
            var dto = new ThemeDTO
            {
                Title = request.Title,
                Description = request.Description,
                WorkType = request.WorkType,
                IsStudentSuggested = request.IsStudentSuggested,
                CreatedByUserId = request.CreatedByUserId,
                SupervisorId = request.SupervisorId,
                StatusId = 1, 
                IsApprovedByDepartment = false
            };

            var result = await themeService.CreateAsync(dto);

            if (result.IsFailed)
                return Result.Failure<ThemeDTO>(result.Error);

            return result;
        }
    }
}

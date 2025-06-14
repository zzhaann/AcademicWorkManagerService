using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Application.UseCases.Theme;
using KDS.Primitives.FluentResult;
using MediatR;

namespace AcademicWorkManagerService.Application.UseCases.Themes
{
    public class UpdateThemeCommandHandler : IRequestHandler<UpdateThemeCommand, Result<ThemeDTO>>
    {
        private readonly IThemeService themeService;

        public UpdateThemeCommandHandler(IThemeService themeService)
        {
            this.themeService = themeService;
        }

        public async Task<Result<ThemeDTO>> Handle(UpdateThemeCommand request, CancellationToken cancellationToken)
        {
            var dto = new ThemeDTO
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                WorkType = request.WorkType,
                IsStudentSuggested = request.IsStudentSuggested,
                SupervisorId = request.SupervisorId,
                StatusId = request.StatusId,
                IsApprovedByDepartment = request.IsApprovedByDepartment
            };

            var result = await themeService.UpdateAsync(request.Id, dto);

            if (result.IsFailed)
                return Result.Failure<ThemeDTO>(result.Error);

            return result;
        }
    }
}

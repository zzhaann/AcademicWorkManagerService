using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Domain.Constants;
using KDS.Primitives.FluentResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.UseCases.Theme
{
    public class GetThemesQueryHandler(IThemeService themeService) : IRequestHandler<GetThemesQuery, Result<ThemeDTO[]>>

    {
        public async Task<Result<ThemeDTO[]>> Handle(GetThemesQuery request, CancellationToken cancellationToken)
        {
            var result = await themeService.GetAllAsync();

            if (result.IsFailed)
                return Result.Failure<ThemeDTO[]>(new Error(ErrorCode.NotFound, "Тем нет."));

            return result;
        }
    }
}

using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Domain.Constants;
using AcademicWorkManagerService.Domain.Entities;
using KDS.Primitives.FluentResult;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ThemeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ThemeDTO>> CreateAsync(ThemeDTO dto)
        {
            var theme = new Theme
            {
                Title = dto.Title,
                Description = dto.Description,
                WorkType = dto.WorkType,
                IsStudentSuggested = dto.IsStudentSuggested,
                CreatedByUserId = dto.CreatedByUserId,
                SupervisorId = dto.SupervisorId,
                StatusId = dto.StatusId,
                IsApprovedByDepartment = dto.IsApprovedByDepartment
            };

            await _unitOfWork.Themes.AddAsync(theme);
            await _unitOfWork.SaveChangesAsync();

            var created = await _unitOfWork.Themes.GetByIdAsync(theme.Id);
            if (created == null)
                return Result.Failure<ThemeDTO>(new Error(ErrorCode.NotFound, "Ошибка при получении созданной темы."));

            dto.Id = created.Id;
            return dto;
        }

        public async Task<Result<ThemeDTO?>> GetByIdAsync(int id)
        {
            var theme = await _unitOfWork.Themes.GetByIdAsync(id);

            if (theme == null)
                return Result.Failure<ThemeDTO?>(new Error(ErrorCode.NotFound, $"Тема с ID {id} не найдена."));

            var dto = new ThemeDTO
            {
                Id = theme.Id,
                Title = theme.Title,
                Description = theme.Description,
                WorkType = theme.WorkType,
                IsStudentSuggested = theme.IsStudentSuggested,
                CreatedByUserId = theme.CreatedByUserId,
                SupervisorId = theme.SupervisorId,
                StatusId = theme.StatusId,
                IsApprovedByDepartment = theme.IsApprovedByDepartment
            };

            return dto;
        }

        public async Task<Result<ThemeDTO[]>> GetAllAsync()
        {
            var themes = await _unitOfWork.Themes.GetAllAsync();

            if (!themes.Any())
                return Result.Failure<ThemeDTO[]>(new Error(ErrorCode.NotFound, "Тем нет."));

            var result = themes.Select(theme => new ThemeDTO
            {
                Id = theme.Id,
                Title = theme.Title,
                Description = theme.Description,
                WorkType = theme.WorkType,
                IsStudentSuggested = theme.IsStudentSuggested,
                CreatedByUserId = theme.CreatedByUserId,
                SupervisorId = theme.SupervisorId,
                StatusId = theme.StatusId,
                IsApprovedByDepartment = theme.IsApprovedByDepartment
            }).ToArray();

            return result;
        }

        public async Task<Result<ThemeDTO>> UpdateAsync(int id, ThemeDTO dto)
        {
            var theme = await _unitOfWork.Themes.GetByIdAsync(id);

            if (theme == null)
                return Result.Failure<ThemeDTO>(new Error(ErrorCode.NotFound, $"Тема с ID {id} не найдена."));

            theme.Title = dto.Title;
            theme.Description = dto.Description;
            theme.WorkType = dto.WorkType;
            theme.IsStudentSuggested = dto.IsStudentSuggested;
            theme.SupervisorId = dto.SupervisorId;
            theme.StatusId = dto.StatusId;
            theme.IsApprovedByDepartment = dto.IsApprovedByDepartment;

            await _unitOfWork.Themes.UpdateAsync(theme);
            await _unitOfWork.SaveChangesAsync();

            var updated = await _unitOfWork.Themes.GetByIdAsync(id);
            if (updated == null)
                return Result.Failure<ThemeDTO>(new Error(ErrorCode.NotFound, "Ошибка при получении обновлённой темы."));

            dto.Id = updated.Id;
            return dto;
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            var theme = await _unitOfWork.Themes.GetByIdAsync(id);

            if (theme == null)
                return Result.Failure<bool>(new Error(ErrorCode.NotFound, $"Тема с ID {id} не найдена."));

            await _unitOfWork.Themes.RemoveAsync(theme);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}

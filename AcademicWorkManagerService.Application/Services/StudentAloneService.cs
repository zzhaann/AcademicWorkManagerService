using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Domain.Constants;
using AcademicWorkManagerService.Domain.Entities;
using KDS.Primitives.FluentResult;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.Services
{
    public class StudentAloneService : IStudentAloneService
    {
      private readonly IUnitOfWork _unitOfWork;

        public StudentAloneService(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<StudentAloneDTO>> CreateAsync(int studentId, int themeId)
        {
            var exists = await _unitOfWork.StudentAlone.GetByStudentAndThemeAsync(studentId, themeId);
            if (exists != null)
                return Result.Failure<StudentAloneDTO>(new Error(ErrorCode.Conflict, "Студент уже выбрал эту тему."));

            var entity = new StudentAlone
            {
                StudentId = studentId,
                ThemeId = themeId
            };

            await _unitOfWork.StudentAlone.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            var dto = new StudentAloneDTO
            {
                Id = entity.Id,
                StudentId = entity.StudentId,
                ThemeId = entity.ThemeId
            };

            return Result.Success(dto);
        }


        public async Task<Result<StudentAloneDTO?>> GetByStudentAsync(int studentId)
        {
            var entity = await _unitOfWork.StudentAlone.FindAsync(x => x.StudentId == studentId);
            var first = entity.FirstOrDefault();

            if(first == null)
                return Result.Failure<StudentAloneDTO?>(new Error(ErrorCode.NotFound, "Нет заявки от студента."));

            return new StudentAloneDTO
            {
                Id = first.Id,
                StudentId = first.StudentId,
                ThemeId = first.ThemeId
            };
        }


        public async Task<Result<StudentAloneDTO[]>> GetAllAsync()
        {
            var all = await _unitOfWork.StudentAlone.GetAllAsync();

            if (!all.Any())
                return Result.Failure<StudentAloneDTO[]>(new Error(ErrorCode.NotFound, "Нет заявок."));

            var dtos = all.Select(sa => new StudentAloneDTO
            {
                Id = sa.Id,
                StudentId=sa.StudentId,
                ThemeId = sa.ThemeId
            }).ToArray();
            return dtos;
        }


        public async Task<Result<StudentAloneDTO>> UpdateAsync(int id, int newThemeId)
        {
            var entity = await _unitOfWork.StudentAlone.GetByIdAsync(id);
            if (entity == null)
                return Result.Failure<StudentAloneDTO>(new Error(ErrorCode.NotFound, "Заявка не найдена."));

            entity.ThemeId = newThemeId;

            await _unitOfWork.StudentAlone.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            var dto = new StudentAloneDTO
            {
                Id = entity.Id,
                StudentId = entity.StudentId,
                ThemeId = entity.ThemeId
            };

            return Result.Success(dto);
        }



        public async Task<Result<bool>> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.StudentAlone.GetByIdAsync(id);
            if (entity == null)
                return Result.Failure<bool>(new Error(ErrorCode.NotFound, "Заявка не найдена."));

            await _unitOfWork.StudentAlone.RemoveAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success(true);
        }


    }
}

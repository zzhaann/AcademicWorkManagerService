using AcademicWorkManagerService.Application.DTO;
using KDS.Primitives.FluentResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.Interfaces
{
    public interface IStudentAloneService
    {
        Task<Result<StudentAloneDTO>> CreateAsync(int studentId, int themeId);
        Task<Result<StudentAloneDTO?>> GetByStudentAsync(int studentId);

        Task<Result<StudentAloneDTO[]>> GetAllAsync();
        Task<Result<StudentAloneDTO>> UpdateAsync(int id, int newThemeId);


        Task<Result<bool>> DeleteAsync(int id);
    }
}

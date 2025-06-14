using AcademicWorkManagerService.Application.DTO;
using KDS.Primitives.FluentResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.Interfaces
{
    public interface IThemeService
    {
        Task<Result<ThemeDTO>> CreateAsync(ThemeDTO dto);
        Task<Result<ThemeDTO?>> GetByIdAsync(int id);
        Task<Result<ThemeDTO[]>> GetAllAsync(); 
        Task<Result<ThemeDTO>> UpdateAsync(int id, ThemeDTO dto); 
        Task<Result<bool>> DeleteAsync(int id); 
    }
}

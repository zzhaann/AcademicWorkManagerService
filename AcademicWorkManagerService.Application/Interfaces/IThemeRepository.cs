using AcademicWorkManagerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.Interfaces
{
    public interface IThemeRepository : IRepository<Theme>
    {
        Task<IEnumerable<Theme>> GetAllWithSupervisorAsync();
        Task<Theme?> GetByIdWithSupervisorAsync(int id);
    }
}

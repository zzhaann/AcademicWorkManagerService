using AcademicWorkManagerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.Interfaces
{
    public interface IStudentAloneRepository : IRepository<StudentAlone>
    {
        Task<StudentAlone?> GetByStudentAndThemeAsync(int studentId, int themeId);
    }
}

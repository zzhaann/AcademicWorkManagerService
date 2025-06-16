using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Domain.Entities;
using AcademicWorkManagerService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Infrastructure.Repositories
{
    public class StudentAloneRepository : Repository<StudentAlone>, IStudentAloneRepository
    {
        public StudentAloneRepository(AppDbContext context) : base(context) { }

        public async Task<StudentAlone?> GetByStudentAndThemeAsync(int studentId, int themeId)
        {
            return await _context.StudentAlones.FirstOrDefaultAsync(sa => sa.StudentId == studentId && sa.ThemeId == themeId);


        }
    }
}

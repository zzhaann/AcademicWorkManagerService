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
    public class ThemeRepository : Repository<Theme>, IThemeRepository
    {
        public ThemeRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Theme>> GetAllWithSupervisorAsync()
        {
            return await _context.Themes.Include(t => t.Supervisor).ToListAsync();
        }

        public async Task<Theme?> GetByIdWithSupervisorAsync(int id)
        {
            return await _context.Themes.Include(t => t.Supervisor).FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}

using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Domain.Entities;
using AcademicWorkManagerService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Infrastructure.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Role?> GetByNameAsync(string name)
        {
            return await _context.Roles
                .FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}

using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Domain.Entities;
using AcademicWorkManagerService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == username);
        }
        
        public async Task<User?> GetByUsernameWithRoleAsync(string username)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UserName == username);
        }
        
        public async Task<User?> GetByIdWithRoleAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        
        public async Task<IEnumerable<User>> GetAllWithRolesAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
        
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}

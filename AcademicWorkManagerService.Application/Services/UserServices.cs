using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Domain.Entities;
using AcademicWorkManagerService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserDTO[]> GetAllAsync()
        {
            return await _context.users
                .Select(u => new UserDTO
                {
                    Id = u.id,
                    UserName = u.userName,
                    UserRole = u.userRole
                })
                .ToArrayAsync();
        }

        public async Task<UserDTO?> GetByIdAsync(int id)
        {
            
            var user = await _context.users
                .Where(u => u.id == (int)id)
                .Select(u => new UserDTO
                {
                    Id = u.id,
                    UserName = u.userName,
                    UserRole = u.userRole
                })
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}

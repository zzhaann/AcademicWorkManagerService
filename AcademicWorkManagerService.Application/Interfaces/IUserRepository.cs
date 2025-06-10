using AcademicWorkManagerService.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByUsernameWithRoleAsync(string username);
        Task<User?> GetByIdWithRoleAsync(int id);
        Task<IEnumerable<User>> GetAllWithRolesAsync();
    }
}

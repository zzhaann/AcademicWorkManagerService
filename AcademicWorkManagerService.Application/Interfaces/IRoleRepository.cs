using AcademicWorkManagerService.Domain.Entities;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role?> GetByNameAsync(string name);
    }
}


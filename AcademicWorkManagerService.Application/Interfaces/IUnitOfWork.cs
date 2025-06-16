using AcademicWorkManagerService.Domain.Entities;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        
        IThemeRepository Themes { get; }

        IStudentAloneRepository StudentAlone { get; }
        Task<int> SaveChangesAsync();
    }
}

using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        Task<int> SaveChangesAsync();
    }
}

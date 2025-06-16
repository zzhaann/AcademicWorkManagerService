using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Infrastructure.Services;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IThemeRepository _themeRepository;
        private IStudentAloneRepository _studentAloneRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _userRepository ??= new UserRepository(_context);
        
        public IRoleRepository Roles => _roleRepository ??= new RoleRepository(_context);
        public IThemeRepository Themes => _themeRepository ??= new ThemeRepository(_context);

        public IStudentAloneRepository StudentAlone => _studentAloneRepository ??= new StudentAloneRepository(_context);
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

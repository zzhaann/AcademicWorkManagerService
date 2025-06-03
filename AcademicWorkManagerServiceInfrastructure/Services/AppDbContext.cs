using Microsoft.EntityFrameworkCore;
using AcademicWorkManagerService.Domain.Entities;

namespace AcademicWorkManagerService.Infrastructure.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

    }
}

using AcademicWorkManagerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Infrastructure.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Diploma> Diplomas { get; set; }
        public DbSet<Files> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Student" },
                new Role { Id = 3, Name = "Supervisor" },
                new Role { Id = 4, Name = "Department" },
                new Role { Id = 5, Name = "Manager" },
                new Role { Id = 6, Name = "Expert" },
                new Role { Id = 7, Name = "ViceRector" }
            );
        }
    }
}

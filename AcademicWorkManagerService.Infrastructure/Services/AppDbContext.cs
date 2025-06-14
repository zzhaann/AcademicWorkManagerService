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

        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ThemeStatus> ThemeStatuses { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<ThemeStatusHistory> ThemeStatusHistories { get; set; }
        public DbSet<ThemeApprovalFlow> ThemeApprovalFlows { get; set; }
        public DbSet<StudentTeam> StudentTeams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<StudentAlone> StudentAlones { get; set; }
        public DbSet<ThemeFile> ThemeFiles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedThemes)
                .WithOne(t => t.CreatedByUser)
                .HasForeignKey(t => t.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.SupervisedThemes)
                .WithOne(t => t.Supervisor)
                .HasForeignKey(t => t.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentTeam>()
                .HasMany(t => t.Members)
                .WithOne(m => m.Team)
                .HasForeignKey(m => m.TeamId);

            modelBuilder.Entity<TeamMember>()
                .HasOne(m => m.Student)
                .WithMany(u => u.TeamMemberships)
                .HasForeignKey(m => m.StudentId);

            modelBuilder.Entity<ThemeStatusHistory>()
                .HasOne(h => h.Theme)
                .WithMany(t => t.StatusHistory)
                .HasForeignKey(h => h.ThemeId);

            modelBuilder.Entity<ThemeApprovalFlow>()
                .HasOne(f => f.Theme)
                .WithMany(t => t.ApprovalFlow)
                .HasForeignKey(f => f.ThemeId);

            modelBuilder.Entity<ThemeFile>()
                .HasOne(f => f.Theme)
                .WithMany(t => t.Files)
                .HasForeignKey(f => f.ThemeId);

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

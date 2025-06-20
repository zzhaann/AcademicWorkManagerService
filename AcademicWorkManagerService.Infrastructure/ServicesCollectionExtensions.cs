﻿using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Infrastructure.Repositories;
using AcademicWorkManagerService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcademicWorkManagerService.Infrastructure
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region db
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString), ServiceLifetime.Scoped);
            #endregion

            #region Repositories
            services.AddScoped<IThemeRepository, ThemeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentAloneRepository, StudentAloneRepository>();
            #endregion


            return services;
        }
    }
}

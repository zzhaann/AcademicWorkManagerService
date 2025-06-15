using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace AcademicWorkManagerService.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IThemeService, ThemeService>();

            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;


namespace AcademicWorkManagerService.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));
            return services;
        }
    }
}

using AcademicWorkManagerService.Domain.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcademicWorkManagerService.Domain
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDomainOptions(configuration);

            return services;
        }

        public static IServiceCollection AddDomainOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtConfigurationOptions>(configuration.GetSection(JwtConfigurationOptions.SectionName));
            return services;
        }

    }
}

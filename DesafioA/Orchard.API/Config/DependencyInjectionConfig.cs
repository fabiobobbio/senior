using Microsoft.Extensions.DependencyInjection;
using Orchard.Domain.Interfaces;
using Orchard.Domain.Services;
using Orchard.Repository;
using Orchard.Repository.Notifications;

namespace Orchard.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<OrchardContext>();

            services.AddScoped<ITreeRepository, TreeRepository>();
            services.AddScoped<ITreeService, TreeService>();
            services.AddScoped<IHarvestRepository, HarvestRepository>();
            services.AddScoped<IHarvestService, HarvestService>();
            services.AddScoped<ITreeGroupRepository, TreeGroupRepository>();
            services.AddScoped<ITreeGroupService, TreeGroupService>();
            services.AddScoped<ISpecieRepository, SpecieRepository>();
            services.AddScoped<ISpecieService, SpecieService>();

            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}
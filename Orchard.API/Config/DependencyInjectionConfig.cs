using Microsoft.Extensions.DependencyInjection;
using Orchard.Repository;
using Orchard.Repository.Interfaces;
using Orchard.Repository.Notifications;

namespace Orchard.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<OrchardContext>();

            //services.AddScoped<ITreeRepository, TreeRepository>();

            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}
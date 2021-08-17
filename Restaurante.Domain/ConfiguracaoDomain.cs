using Microsoft.Extensions.DependencyInjection;
using Restaurante.Domain.Comum;

namespace Restaurante.Domain
{
    public static class ConfiguracaoDomain
    {
        public static IServiceCollection AddDomain(this IServiceCollection services) =>
            services.AddFactories();
        private static IServiceCollection AddFactories(this IServiceCollection services) =>
            services.Scan(scan => scan
                            .FromCallingAssembly()
                            .AddClasses(classes =>
                                classes.AssignableTo(typeof(IFactory<>)))
                                .AsMatchingInterface()
                                .WithTransientLifetime());
    }
}

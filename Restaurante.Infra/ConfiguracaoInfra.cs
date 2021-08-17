using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurante.Domain.Usuarios.Repositorios;
using Restaurante.Infra.Comum.Persistencia;
using Restaurante.Infra.Usuarios.Clientes;

namespace Restaurante.Infra
{
    public static class ConfiguracaoInfra
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration) =>        
            services
                .AddDatabase(configuration)
                .AddRepositorios();

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<RestauranteDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("Default"),
                                            sqlServer => sqlServer
                                                        .MigrationsAssembly(typeof(RestauranteDbContext).Assembly.FullName)))
                .AddScoped<IRestauranteDbContext>(provider => provider.GetService<RestauranteDbContext>());

        internal static IServiceCollection AddRepositorios(this IServiceCollection services) =>
            services.
                Scan(scan => scan
                        .FromCallingAssembly()
                        .AddClasses(classes => classes
                                .AssignableTo(typeof(IDomainRepositorio<>)))
                        .AsImplementedInterfaces()
                        .WithTransientLifetime());
    }
}

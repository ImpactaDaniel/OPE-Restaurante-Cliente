using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurante.Clientes.Infra.Usuarios.Encoder.Interfaces;
using Restaurante.Domain.Usuarios.Modelos.Intefaces;
using Restaurante.Domain.Usuarios.Repositorios.Interfaces;
using Restaurante.Infra.Comum.Persistencia;
using Restaurante.Infra.Usuarios.Clientes;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Restaurante.Clientes.Test")]
namespace Restaurante.Infra
{
    public static class ConfiguracaoInfra
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration) =>        
            services
                .AddDatabase(configuration)
                .AddValidators()
                .AddEncoders()
                .AddRepositorios();

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<RestauranteDbContext>(options =>
                    options.UseSqlite(configuration.GetConnectionString("Default"),
                                            sqlServer => sqlServer
                                                        .MigrationsAssembly(typeof(RestauranteDbContext).Assembly.FullName)))
                .AddScoped<IRestauranteDbContext>(provider => provider.GetService<RestauranteDbContext>());

        internal static IServiceCollection AddValidators(this IServiceCollection services) =>
             services.Scan(scan => scan
                        .FromCallingAssembly()
                        .AddClasses(classes => classes
                                .AssignableTo(typeof(IValidator<>)))
                        .AsImplementedInterfaces()
                        .WithTransientLifetime());

        internal static IServiceCollection AddRepositorios(this IServiceCollection services) =>
            services.
                Scan(scan => scan
                        .FromCallingAssembly()
                        .AddClasses(classes => classes
                                .AssignableTo(typeof(IDomainRepositorio<>)))
                        .AsImplementedInterfaces()
                        .WithTransientLifetime());
        internal static IServiceCollection AddEncoders(this IServiceCollection services) =>
            services.
                Scan(scan => scan
                        .FromCallingAssembly()
                        .AddClasses(classes => classes
                                .AssignableTo(typeof(IEncoder)))
                        .AsImplementedInterfaces()
                        .WithTransientLifetime());
    }
}

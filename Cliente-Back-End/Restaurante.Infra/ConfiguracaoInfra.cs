using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurante.Clientes.Infra.Usuarios.Encoder.Interfaces;
using Restaurante.Domain.Usuarios.Modelos.Intefaces;
using Restaurante.Domain.Usuarios.Repositorios.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Restaurante.Clientes.Test")]
namespace Restaurante.Infra
{
    public static class ConfiguracaoInfra
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddValidators()
                .AddEncoders()
                .AddRepositorios();

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

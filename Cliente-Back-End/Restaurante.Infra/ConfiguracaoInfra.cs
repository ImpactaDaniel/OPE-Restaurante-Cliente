using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurante.Clientes.Infra.Usuarios.Encoder.Interfaces;
using Restaurante.Clientes.Integracoes.Config;
using Restaurante.Domain.Usuarios.Modelos.Intefaces;
using Restaurante.Domain.Usuarios.Repositorios.Interfaces;
using Restaurante.Integrations;
using System.Net.Http;
using System.Runtime.CompilerServices;
using AutoMapper;
using Restaurante.Clientes.Infra.Comum.Mapper;
using Restaurante.Clientes.Domain.Usuarios.Repositorios.Interfaces;
using Restaurante.Clientes.Integracoes.EventBus.Interfaces;
using Restaurante.Clientes.Integracoes.EventBus.Implementations;
using Restaurante.Clientes.Infra.EventBus;
using Restaurante.Clientes.Application.Hubs.Services.Intefaces;
using Microsoft.AspNetCore.Builder;

[assembly: InternalsVisibleTo("Restaurante.Clientes.Test")]
namespace Restaurante.Infra
{
    public static class ConfiguracaoInfra
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddValidators()
                .AddAutoMapper(typeof(MapperProfile))
                .AddIntegrations(configuration)
                .AddEncoders()
                .AddRepositorios();

        internal static IServiceCollection AddValidators(this IServiceCollection services) =>
             services.Scan(scan => scan
                        .FromCallingAssembly()
                        .AddClasses(classes => classes
                                .AssignableTo(typeof(IValidator<>)))
                        .AsImplementedInterfaces()
                        .WithTransientLifetime());

        internal static IServiceCollection AddIntegrations(this IServiceCollection services, IConfiguration config)
        {
            var integrationSettings = config.GetSection(nameof(IntegrationSettings)).Get<IntegrationSettings>();

            services.AddSingleton(integrationSettings);

            var restauranteService = new RestauranteService(integrationSettings.UrlRestauranteService, new HttpClient());

            services.AddSingleton(restauranteService);

            services.AddSingleton<IEventBus, AzureEventBus>();

            return services;
        }

        public static void ConfigureEventBus(this IApplicationBuilder app)
        {            
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            var invoiceHubService = app.ApplicationServices.GetRequiredService<IInvoiceHubService>();

            eventBus.Subscribe(new InvoiceQueueHandler(invoiceHubService));
        }

        internal static IServiceCollection AddRepositorios(this IServiceCollection services) =>
            services.
                Scan(scan => scan
                        .FromCallingAssembly()
                        .AddClasses(classes => classes
                                .AssignableTo(typeof(IRepository)))
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

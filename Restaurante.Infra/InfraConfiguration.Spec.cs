using Microsoft.Extensions.DependencyInjection;
using Restaurante.Infra.Comum.Persistencia;
using Restaurante.Infra.Usuarios.Clientes;
using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Restaurante.Domain.Usuarios.Repositorios.Interfaces;

namespace Restaurante.Infra
{
    public class InfraConfiguration
    {
        [Fact]
        public void DeveraRegistrarRepositorios()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<RestauranteDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<IRestauranteDbContext>(provider => provider.GetService<RestauranteDbContext>());

            // Act
            var services = 
                serviceCollection
                .AddValidators()
                .AddEncoders()
                .AddRepositorios()
                .BuildServiceProvider();

            // Assert
            Assert.NotNull(services
                .GetService<IClienteDomainRepositorio>());
        }
    }
}

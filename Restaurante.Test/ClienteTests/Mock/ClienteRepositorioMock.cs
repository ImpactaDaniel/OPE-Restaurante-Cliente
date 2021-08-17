using Microsoft.EntityFrameworkCore;
using Restaurante.Infra.Comum.Persistencia;
using Restaurante.Infra.Usuarios.Clientes;

namespace Restaurante.Test.ClienteTests.Mock
{
    public static class ClienteRepositorioMock
    {

        public static IRestauranteDbContext GetDbContextPadraoUsingMemoryDatabase()
        {
            var options = new DbContextOptionsBuilder<RestauranteDbContext>()
                .UseInMemoryDatabase("ClientDomainRepository")
                .Options;

            var dbContext = new RestauranteDbContext(options);

            return dbContext;
        }
    }
}

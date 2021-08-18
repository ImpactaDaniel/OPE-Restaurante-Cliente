using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Domain.Usuarios.Repositorios;
using Restaurante.Infra.Comum.Persistencia;
using Restaurante.Infra.Usuarios.Clientes;
using System;
using System.Threading.Tasks;

namespace Restaurante.Test.ClienteTests.Mock
{
    public static class ClienteRepositorioMock
    {

        public static IRestauranteDbContext GetDbContextPadraoUsingMemoryDatabase(string guid)
        {
            var options = new DbContextOptionsBuilder<RestauranteDbContext>()
                .UseInMemoryDatabase(guid)
                .Options;

            var dbContext = new RestauranteDbContext(options);

            return dbContext;
        }

        public async static Task<IClienteDomainRepositorio> GetContextUsingInMemoryDBComClienteInserido(Cliente cliente)
        {
            var repositorio = new ClienteRepositorio(GetDbContextPadraoUsingMemoryDatabase(Guid.NewGuid().ToString()), ClienteValidatorMock.ClienteValidatorMockPadrao());

            await repositorio.Salvar(cliente);

            return repositorio;
        }
    }
}

using Restaurante.Application.Usuarios.Clientes.Requsicoes.Buscar;
using Restaurante.Infra.Usuarios.Clientes;
using Restaurante.Test.ClienteTests.Mock;
using System;
using System.Threading.Tasks;
using Xunit;
using static Restaurante.Application.Usuarios.Clientes.Requsicoes.Buscar.BuscarClientePorIdRequisicao;

namespace Restaurante.Test.ClienteTests
{
    public class BuscarClienteRequisicaoHandlerHandle
    {
        [Fact]
        public async Task DeveRetornarUmClienteCriadoNoBd()
        {
            //Arrange
            var cliente = await ClienteMock.GetClientePadrao();

            var repositorio = await ClienteRepositorioMock.GetContextUsingInMemoryDBComClienteInserido(cliente);

            var comandoBusca = new BuscarClientePorIdRequisicao() { Id = cliente.Id};

            var handlerBuscar = new BuscarClientePorIdRequisicaoHandler(repositorio);

            //Act
            var clienteBusca = await handlerBuscar.Handle(comandoBusca, new System.Threading.CancellationToken());

            //Assert
            Assert.NotNull(clienteBusca);
        }

        [Fact]
        public async Task DeveLancarExcecaoQuandoNaoAcharCliente()
        {
            //Arrange
            var clientePadrao = ClienteMock.GetClientePadrao();

            var repositorio = new ClienteRepositorio(ClienteRepositorioMock.GetDbContextPadraoUsingMemoryDatabase(Guid.NewGuid().ToString()));

            var comandoBusca = new BuscarClientePorIdRequisicao() { Id = clientePadrao.Id };

            var handlerBuscar = new BuscarClientePorIdRequisicaoHandler(repositorio);

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                //Act
                await handlerBuscar.Handle(comandoBusca, new System.Threading.CancellationToken())
            );
        }
    }
}

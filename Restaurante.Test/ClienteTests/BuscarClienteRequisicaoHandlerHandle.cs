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
            Assert.True(clienteBusca.Sucesso);
            Assert.NotNull(clienteBusca.Entidade);
        }

        [Fact]
        public async Task DeveRetornarEntidadeNulaESucessoFalseQuandoNaoEncontrar()
        {
            //Arrange
            var clientePadrao = ClienteMock.GetClientePadrao();

            var repositorio = new ClienteRepositorio(ClienteRepositorioMock.GetDbContextPadraoUsingMemoryDatabase(Guid.NewGuid().ToString()), ClienteValidatorMock.ClienteValidatorMockPadrao());

            var comandoBusca = new BuscarClientePorIdRequisicao() { Id = clientePadrao.Id };

            var handlerBuscar = new BuscarClientePorIdRequisicaoHandler(repositorio);

            //Act
            var resposta = await handlerBuscar.Handle(comandoBusca, new System.Threading.CancellationToken());

            //Assert
            Assert.False(resposta.Sucesso);
            Assert.Null(resposta.Entidade);
        }
    }
}

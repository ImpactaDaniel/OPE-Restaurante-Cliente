using NSubstitute;
using Restaurante.Application.Usuarios.Clientes.Requsicoes.Buscar;
using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Comum.Modelos.Intefaces;
using Restaurante.Infra.Usuarios.Clientes;
using Restaurante.Test.ClienteTests.Mock;
using System;
using System.Threading.Tasks;
using Xunit;
using static Restaurante.Application.Usuarios.Clientes.Requsicoes.Buscar.BuscarClientePorIdRequisicao;

namespace Restaurante.Test.ClienteTests
{
    public class BuscarClienteRequisicaoHandlerTest
    {

        private readonly IClienteValidator _clienteValidator;

        public BuscarClienteRequisicaoHandlerTest()
        {
            _clienteValidator = Substitute.For<IClienteValidator>();

            _clienteValidator.Validar(default).ReturnsForAnyArgs(new Resposta());
        }

        [Fact]
        public async Task DeveRetornarUmClienteCriadoNoBd()
        {
            //Arrange
            var cliente = await ClienteMock.GetClientePadrao();

            var repositorio = await ClienteRepositorioMock.GetContextUsingInMemoryDBComClienteInserido(cliente, _clienteValidator);

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

            var repositorio = new ClienteRepositorio(ClienteRepositorioMock.GetDbContextPadraoUsingMemoryDatabase(Guid.NewGuid().ToString()), _clienteValidator);

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

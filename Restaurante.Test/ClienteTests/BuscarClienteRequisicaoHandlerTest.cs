using NSubstitute;
using Restaurante.Application.Usuarios.Clientes.Requsicoes.Buscar;
using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Comum.Modelos.Intefaces;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Domain.Usuarios.Repositorios;
using Restaurante.Test.ClienteTests.Mock;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static Restaurante.Application.Usuarios.Clientes.Requsicoes.Buscar.BuscarClientePorIdRequisicao;

namespace Restaurante.Test.ClienteTests
{
    public class BuscarClienteRequisicaoHandlerTest
    {

        private readonly IClienteValidator _clienteValidator;
        private readonly IClienteDomainRepositorio _repositorio;

        public BuscarClienteRequisicaoHandlerTest()
        {
            _clienteValidator = Substitute.For<IClienteValidator>();
            _repositorio = Substitute.For<IClienteDomainRepositorio>();
            _clienteValidator.Validar(default).ReturnsForAnyArgs(new Resposta());
        }

        [Fact]
        public async Task DeveRetornarUmClienteCriadoNoBd()
        {
            //Arrange
            var cliente = await ClienteMock.GetClientePadrao();

            _repositorio.Buscar(default).ReturnsForAnyArgs(new RespostaConsulta<Cliente>(await ClienteMock.GetClientePadrao()));

            var comandoBusca = new BuscarClientePorIdRequisicao() { Id = cliente.Id};

            var handlerBuscar = new BuscarClientePorIdRequisicaoHandler(_repositorio);

            //Act
            var clienteBusca = await handlerBuscar.Handle(comandoBusca, new System.Threading.CancellationToken());

            //Assert
            Assert.True(clienteBusca.Sucesso);
            Assert.Null(clienteBusca.Erros);
            Assert.NotNull(clienteBusca.Entidade);
        }

        [Fact]
        public async Task DeveRetornarEntidadeNulaESucessoFalseQuandoNaoEncontrar()
        {
            //Arrange
            var clientePadrao = ClienteMock.GetClientePadrao();

            var erros = new List<string>() { "Erro" };

            _repositorio.Buscar(default).ReturnsForAnyArgs(new RespostaConsulta<Cliente>(erros));

            var comandoBusca = new BuscarClientePorIdRequisicao() { Id = clientePadrao.Id };

            var handlerBuscar = new BuscarClientePorIdRequisicaoHandler(_repositorio);

            //Act
            var resposta = await handlerBuscar.Handle(comandoBusca, new System.Threading.CancellationToken());

            //Assert
            Assert.False(resposta.Sucesso);
            Assert.True(resposta.Erros?.Any());
            Assert.Null(resposta.Entidade);
        }
    }
}

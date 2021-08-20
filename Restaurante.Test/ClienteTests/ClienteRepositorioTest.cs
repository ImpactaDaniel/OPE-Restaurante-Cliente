using NSubstitute;
using Restaurante.Domain.Comum.Modelos.Intefaces;
using Restaurante.Infra.Usuarios.Clientes;
using Restaurante.Test.ClienteTests.Mock;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Restaurante.Clientes.Test.ClienteTests
{
    public class ClienteRepositorioTest
    {
        private readonly IClienteValidator _clienteValidator;

        public ClienteRepositorioTest()
        {
            _clienteValidator = Substitute.For<IClienteValidator>();
            _clienteValidator.Validar(default).ReturnsForAnyArgs(new Domain.Comum.Modelos.Resposta());
        }

        [Fact]
        public async Task DadoClienteValidoDeveSerInseridoNoBD()
        {
            //arrange
            var repositorio = new ClienteRepositorio(ClienteRepositorioMock.GetDbContextPadraoUsingMemoryDatabase(Guid.NewGuid().ToString()), _clienteValidator);
            var cliente = await ClienteMock.GetClientePadrao();

            //act
            var resposta = await repositorio.Salvar(cliente);

            //assert
            Assert.True(resposta.Sucesso);
            Assert.Null(resposta.Erros);
        }

        [Fact]
        public async Task DadoIdDeClienteExistenteDeveRetornar()
        {
            //arrange
            var cliente = await ClienteMock.GetClientePadrao();

            var repositorio = await ClienteRepositorioMock.GetContextUsingInMemoryDBComClienteInserido(cliente, _clienteValidator);

            //act
            var resposta = await repositorio.Buscar(cliente.Id);

            //assert
            Assert.True(resposta.Sucesso);
            Assert.Null(resposta.Erros);
            Assert.NotNull(resposta.Resposta);
        }

        [Fact]
        public async Task DadoIdDeClienteNaoExistenteNaoDeveRetornar()
        {
            //arrange
            var cliente = await ClienteMock.GetClientePadrao();

            var repositorio = new ClienteRepositorio(ClienteRepositorioMock.GetDbContextPadraoUsingMemoryDatabase(Guid.NewGuid().ToString()), _clienteValidator);

            //act
            var resposta = await repositorio.Buscar(cliente.Id);

            //assert
            Assert.False(resposta.Sucesso);
            Assert.Contains(resposta.Erros, e => e == "Cliente não encontrado!");
            Assert.Null(resposta.Resposta);
        }
    }
}

using Xunit;
using System.Threading.Tasks;
using Restaurante.Test.ClienteTests.Mock;
using Restaurante.Application.Usuarios.Clientes.Requsicoes.Criar;
using static Restaurante.Application.Usuarios.Clientes.Requsicoes.Criar.CriarClienteRequisicao;
using Restaurante.Infra.Usuarios.Clientes;
using System;
using System.Linq;
using Restaurante.Domain.Comum.Modelos.Intefaces;
using NSubstitute;
using Restaurante.Domain.Comum.Modelos;
using System.Collections.Generic;

namespace Restaurante.Test.ClienteTests
{
    public class CriarClienteRequisicaoHandlerTest
    {
        private readonly IClienteValidator _clienteValidator;
        public CriarClienteRequisicaoHandlerTest()
        {
            _clienteValidator = Substitute.For<IClienteValidator>();
        }

        [Fact]
        public async Task DadoUmClienteValidoDeveSerCriadoNoBd()
        {

            //Arrange
            _clienteValidator.Validar(default).ReturnsForAnyArgs(new Resposta());

            var factory = FactoryMock.GetClienteFactory();

            var repositorio = new ClienteRepositorio(ClienteRepositorioMock.GetDbContextPadraoUsingMemoryDatabase(Guid.NewGuid().ToString()), _clienteValidator);

            var handler = new CriarClienteRequisicaoHandler(factory, repositorio);

            var comando = new CriarClienteRequisicao(await ClienteMock.GetClientePadrao());

            //act
            var client = await handler.Handle(comando, new System.Threading.CancellationToken());

            //assert
            Assert.True(client.Sucesso);
        }

        [Fact]
        public async Task DadoUmClienteInformacoesInvalidasNaoDeveSerCriadoNoBd()
        {
            //Arrange
            var factory = FactoryMock.GetClienteFactory();
            _clienteValidator.Validar(default).ReturnsForAnyArgs(new Resposta(false, new List<string>() { "Erro" }));

            var repositorio = new ClienteRepositorio(ClienteRepositorioMock.GetDbContextPadraoUsingMemoryDatabase(Guid.NewGuid().ToString()), _clienteValidator);

            var handler = new CriarClienteRequisicaoHandler(factory, repositorio);

            var comando = new CriarClienteRequisicao(await ClienteMock.GetClientePadrao());

            //act
            var client = await handler.Handle(comando, new System.Threading.CancellationToken());

            //assert
            Assert.False(client.Sucesso);
            Assert.True(client.Erros?.Count() > 0);
        }
    }
}

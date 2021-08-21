using Xunit;
using System.Threading.Tasks;
using Restaurante.Test.ClienteTests.Mock;
using Restaurante.Application.Usuarios.Clientes.Requsicoes.Criar;
using static Restaurante.Application.Usuarios.Clientes.Requsicoes.Criar.CriarClienteRequisicao;
using System.Linq;
using Restaurante.Domain.Comum.Modelos.Intefaces;
using NSubstitute;
using Restaurante.Domain.Comum.Modelos;
using System.Collections.Generic;
using Restaurante.Domain.Usuarios.Repositorios;
using Restaurante.Domain.Usuarios.Modelos;

namespace Restaurante.Test.ClienteTests
{
    public class CriarClienteRequisicaoHandlerTest
    {
        private readonly IClienteValidator _clienteValidator;
        private readonly IClienteDomainRepositorio _repositorio;
        public CriarClienteRequisicaoHandlerTest()
        {
            _clienteValidator = Substitute.For<IClienteValidator>();
            _repositorio = Substitute.For<IClienteDomainRepositorio>();
        }

        [Fact]
        public async Task DadoUmClienteValidoDeveSerCriadoNoBd()
        {

            //Arrange
            _clienteValidator.Validar(default).ReturnsForAnyArgs(new Resposta());

            var factory = FactoryMock.GetClienteFactory();

            _repositorio.Salvar(default).ReturnsForAnyArgs(new RespostaConsulta<Cliente>(await ClienteMock.GetClientePadrao()));

            var handler = new CriarClienteRequisicaoHandler(factory, _repositorio);

            var comando = new CriarClienteRequisicao(await ClienteMock.GetClientePadrao());

            //act
            var client = await handler.Handle(comando, new System.Threading.CancellationToken());

            //assert
            Assert.True(client.Sucesso);
            Assert.Null(client.Erros);
        }

        [Fact]
        public async Task DadoUmClienteInformacoesInvalidasNaoDeveSerCriadoNoBd()
        {
            //Arrange
            var factory = FactoryMock.GetClienteFactory();
            var erros = new List<string>() { "Erro" };

            _clienteValidator.Validar(default).ReturnsForAnyArgs(new Resposta(false, erros));

            _repositorio.Salvar(default).ReturnsForAnyArgs(new RespostaConsulta<Cliente>(erros));

            var handler = new CriarClienteRequisicaoHandler(factory, _repositorio);

            var comando = new CriarClienteRequisicao(await ClienteMock.GetClientePadrao());

            //act
            var client = await handler.Handle(comando, new System.Threading.CancellationToken());

            //assert
            Assert.False(client.Sucesso);
            Assert.True(client.Erros?.Count() > 0);
        }
    }
}

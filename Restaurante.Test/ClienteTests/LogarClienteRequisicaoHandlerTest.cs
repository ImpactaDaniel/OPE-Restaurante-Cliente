using NSubstitute;
using Restaurante.Clientes.Application.Usuarios.Clientes.Requsicoes.Autenticar;
using Restaurante.Clientes.Domain.Comum.Modelos.Intefaces;
using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Comum.Modelos.Intefaces;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Domain.Usuarios.Repositorios;
using Restaurante.Test.ClienteTests.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Restaurante.Clientes.Application.Usuarios.Clientes.Requsicoes.Autenticar.AutenticarClienteRequisicao;

namespace Restaurante.Clientes.Test.ClienteTests
{
    public class LogarClienteRequisicaoHandlerTest
    {
        private readonly IClienteDomainRepositorio _repositorio;
        private readonly ITokenService _tokenService;

        public LogarClienteRequisicaoHandlerTest()
        {
            _repositorio = Substitute.For<IClienteDomainRepositorio>();
            _tokenService = Substitute.For<ITokenService>();
        }

        [Fact]
        public async Task DadoUmClienteValidoDeveLogar()
        {
            //Arrange
            _repositorio.Logar(default, default).ReturnsForAnyArgs(new RespostaConsulta<Cliente>(await ClienteMock.GetClientePadrao()));

            var handler = new AutenticarClienteRequisicaoHandler(_repositorio, _tokenService);

            var comando = new AutenticarClienteRequisicao();

            //Act
            var clienteBusca = await handler.Handle(comando, new System.Threading.CancellationToken());

            Assert.True(clienteBusca.Sucesso);
            Assert.Null(clienteBusca.Erros);
        }

        [Fact]
        public async Task DadoUmClienteInValidoNãoDeveLogar()
        {
            //Arrange
            var erros = new List<string>() { "Erro" };

            _repositorio.Logar(default, default).ReturnsForAnyArgs(new RespostaConsulta<Cliente>(erros));

            var handler = new AutenticarClienteRequisicaoHandler(_repositorio, _tokenService);

            var comando = new AutenticarClienteRequisicao();

            //Act
            var clienteBusca = await handler.Handle(comando, new System.Threading.CancellationToken());

            Assert.False(clienteBusca.Sucesso);
            Assert.NotNull(clienteBusca.Erros);
        }
    }
}

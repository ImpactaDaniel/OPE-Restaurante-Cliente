using Xunit;
using System.Threading.Tasks;
using Restaurante.Test.ClienteTests.Mock;
using Restaurante.Application.Usuarios.Clientes.Requsicoes.Criar;
using static Restaurante.Application.Usuarios.Clientes.Requsicoes.Criar.CriarClienteRequisicao;
using Restaurante.Infra.Usuarios.Clientes;
using System;
using System.Linq;

namespace Restaurante.Test.ClienteTests
{
    public class CriarClienteRequisicaoHandlerHandle
    {
        [Fact]
        public async Task DadoUmClienteValidoDeveSerCriadoNoBd()
        {

            //Arrange
            var factory = FactoryMock.GetClienteFactory();

            var repositorio = new ClienteRepositorio(ClienteRepositorioMock.GetDbContextPadraoUsingMemoryDatabase(Guid.NewGuid().ToString()), ClienteValidatorMock.ClienteValidatorMockPadrao());

            var handler = new CriarClienteRequisicaoHandler(factory, repositorio);

            var comando = new CriarClienteRequisicao(await ClienteMock.GetClientePadrao());

            //act
            var client = await handler.Handle(comando, new System.Threading.CancellationToken());

            //assert
            Assert.True(client.Sucesso);
        }

        [Theory]
        [InlineData("danielcity1@gmail.com", "123456", "Senha Inválida!")]
        [InlineData("daniel.com", "Daniel@123456", "E-mail Inválido!")]
        public async Task DadoUmClienteInformacoesInvalidasNaoDeveSerCriadoNoBd(string email, string senha, string mensagemEsperada)
        {
            //Arrange
            var factory = FactoryMock.GetClienteFactory();

            var repositorio = new ClienteRepositorio(ClienteRepositorioMock.GetDbContextPadraoUsingMemoryDatabase(Guid.NewGuid().ToString()), ClienteValidatorMock.ClienteValidatorPadrao());

            var handler = new CriarClienteRequisicaoHandler(factory, repositorio);

            var comando = new CriarClienteRequisicao(ClienteMock.GetClienteComEmailESenha(email, senha));

            //act
            var client = await handler.Handle(comando, new System.Threading.CancellationToken());

            //assert
            Assert.False(client.Sucesso);
            Assert.True(client.Erros?.Count() > 0);
            Assert.Contains(client.Erros, e => e == mensagemEsperada);
        }
    }
}

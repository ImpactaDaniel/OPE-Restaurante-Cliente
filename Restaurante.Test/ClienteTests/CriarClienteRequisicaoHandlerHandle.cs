using Xunit;
using System.Threading.Tasks;
using Restaurante.Test.ClienteTests.Mock;
using Restaurante.Application.Usuarios.Clientes.Requsicoes.Criar;
using static Restaurante.Application.Usuarios.Clientes.Requsicoes.Criar.CriarClienteRequisicao;
using Restaurante.Infra.Usuarios.Clientes;
using System;

namespace Restaurante.Test.ClienteTests
{
    public class CriarClienteRequisicaoHandlerHandle
    {
        public CriarClienteRequisicaoHandlerHandle()
        {
        }
        [Fact]
        public async Task DadoUmClienteValidoDeveSerCriadoNoBd()
        {

            //Arrange
            var factory = FactoryMock.GetClienteFactory();

            var repositorio = new ClienteRepositorio(ClienteRepositorioMock.GetDbContextPadraoUsingMemoryDatabase());

            var handler = new CriarClienteRequisicaoHandler(factory, repositorio);

            var comando = new CriarClienteRequisicao(await ClienteMock.GetClientePadrao());

            //act
            var client = await handler.Handle(comando, new System.Threading.CancellationToken());

            //assert
            Assert.True(client.Id > 0);
        }
    }
}

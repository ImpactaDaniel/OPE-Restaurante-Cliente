using Restaurante.Domain.Comum.Modelos.Intefaces;
using Restaurante.Infra.Usuarios.Validators;
using Restaurante.Test.ClienteTests.Mock;
using System.Linq;
using Xunit;

namespace Restaurante.Clientes.Test.ClienteTests
{
    public class ClienteValidatorTest
    {

        private readonly IClienteValidator _clienteValidator;

        public ClienteValidatorTest()
        {
            _clienteValidator = new ClientValidator();
        }

        [Theory]
        [InlineData("daniel@gmail.com", "123456", "Senha Inválida!")]
        [InlineData("daniel.com", "3ss@EhUm4S3nh4V@lid@", "E-mail Inválido!")]        
        public void DadoUmClienteInvalidoDeveRetornarSucessoFalse(string email, string senha, string mensagemEsperada)
        {
            //Arrange
            var cliente = ClienteMock.GetClienteComEmailESenha(email, senha);

            //Act
            var resposta = _clienteValidator.Validar(cliente);

            //Assert
            Assert.False(resposta.Sucesso);
            Assert.True(resposta.Erros?.Any());
            Assert.Contains(resposta.Erros, e => e == mensagemEsperada);
        }

        [Fact]
        public void DadoUmClienteValidoDeveRetornarSucessoTrue()
        {
            //Arrange
            var cliente = ClienteMock.GetClienteComEmailESenha("email@valido.com", "3ss@EhUm4S3nh4V@lid@");

            //Act
            var resposta = _clienteValidator.Validar(cliente);

            //Assert
            Assert.True(resposta.Sucesso);
            Assert.False(resposta.Erros?.Any());
        }
    }
}

using Restaurante.Clientes.Application.Comum;
using Restaurante.Clientes.Domain.Comum.Modelos.Intefaces;
using Restaurante.Test.ClienteTests.Mock;
using System.Threading.Tasks;
using Xunit;

namespace Restaurante.Clientes.Test.ClienteTests
{
    public class TokenServiceTest
    {
        private readonly ITokenService _tokenService;

        public TokenServiceTest()
        {
            var configuration = new TokenConfiguration()
            {
                SecretKey = "TH1S K3Y !S V3RY S3CR3T",
                ValidTime = 2
            };

            _tokenService = new TokenService(configuration);
        }

        [Fact]
        public async Task DadoClienteExistenteDeveRetornarToken()
        {
            //Dado um cliente criado na base
            var cliente = await ClienteMock.GetClientePadrao();

            //Quando tentar criar token
            var @outToken = _tokenService.GenerateToken(cliente);

            //Então token deverá ser criado
            Assert.NotNull(outToken);
            Assert.NotEmpty(outToken.Token);
        }
    }
}

using Moq;
using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Comum.Modelos.Intefaces;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Infra.Usuarios.Validators;

namespace Restaurante.Test.ClienteTests.Mock
{
    public static class ClienteValidatorMock
    {
        public static IClienteValidator ClienteValidatorMockPadrao()
        {
            var mock = new Mock<IClienteValidator>();

            mock.Setup(v => v.Validar(It.IsAny<Cliente>()))
                .Returns(new Resposta());

            return mock.Object;
        }

        public static IClienteValidator ClienteValidatorPadrao() => new ClientValidator();
    }
}

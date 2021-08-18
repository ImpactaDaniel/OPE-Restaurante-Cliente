using Restaurante.Domain.Usuarios.Factories.Clientes;

namespace Restaurante.Test.ClienteTests.Mock
{
    public static class FactoryMock
    {
        public static IClienteFactory GetClienteFactory()
        {
            var factory = new ClienteFactory();
            return factory;
        }
    }
}

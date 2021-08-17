using Moq;
using Restaurante.Domain.Usuarios.Factories.Clientes;
using Restaurante.Domain.Usuarios.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

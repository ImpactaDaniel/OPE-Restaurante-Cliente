using Restaurante.Domain.Usuarios.Modelos;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurante.Test.ClienteTests.Mock
{
    public abstract class ClienteMock
    {
        public static Task<Cliente> GetClientePadrao() =>
            Task.FromResult(new Cliente("Daniel", TelefoneMock.GetTelefonePadrao(), EnderecoMock.GetEnderecoPadrao()));
        public static Task<Cliente> GetClienteSemTelefone() =>
           Task.FromResult(new Cliente("Daniel", null, EnderecoMock.GetEnderecoPadrao()));
    }

    public class CenariosClientesInvalidosTestes : IEnumerable<object[]>
    {
        private readonly List<object[]> _dados = new List<object[]>(2)
        {
            new object[] { EnderecoMock.GetEnderecoPadrao(), "Daniel", null, "Telefone é obrigatório!" },
            new object[] { null, "Daniel", TelefoneMock.GetTelefonePadrao(), "Endereço é obrigatório!" }
        };
        public IEnumerator<object[]> GetEnumerator() =>
            _dados.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>  
            GetEnumerator();
    }
}

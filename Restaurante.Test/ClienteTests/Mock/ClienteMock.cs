using Restaurante.Domain.Usuarios.Modelos;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurante.Test.ClienteTests.Mock
{
    public abstract class ClienteMock
    {
        public static Task<Cliente> GetClientePadrao() =>
            Task.FromResult(new Cliente("Daniel", "daniel", "daniel", TelefoneMock.GetTelefonePadrao(), EnderecoMock.GetEnderecoPadrao()));
        public static Task<Cliente> GetClienteSemTelefone() =>
           Task.FromResult(new Cliente("Daniel", "daniel", "daniel", null, EnderecoMock.GetEnderecoPadrao()));
        public static Cliente GetClienteComEmail(string email) =>
            new Cliente("Daniel", email, "daniel", TelefoneMock.GetTelefonePadrao(), EnderecoMock.GetEnderecoPadrao());
        public static Cliente GetClienteComSenha(string senha) =>
            new Cliente("Daniel", "daniel", senha, TelefoneMock.GetTelefonePadrao(), EnderecoMock.GetEnderecoPadrao());

        public static Cliente GetClienteComEmailESenha(string email, string senha) =>
            new Cliente("Daniel", email, senha, TelefoneMock.GetTelefonePadrao(), EnderecoMock.GetEnderecoPadrao());
    }

    public class CenariosClientesInvalidosTestes : IEnumerable<object[]>
    {
        //(Endereco endereco, string nome, string email, string senha, Telefone telefone, string mensagemEsperada
        private readonly List<object[]> _dados = new List<object[]>(2)
        {
            new object[] { EnderecoMock.GetEnderecoPadrao(), "Daniel", "daniel@gmail.com", "123456", null, "Telefone é obrigatório!" },
            new object[] { null, "Daniel", "daniel@gmail.com", "123456", TelefoneMock.GetTelefonePadrao(), "Endereço é obrigatório!" },
            new object[] { EnderecoMock.GetEnderecoPadrao(), "Daniel", string.Empty, "123456", TelefoneMock.GetTelefonePadrao(), "E-mail é obrigatório!" },
            new object[] { EnderecoMock.GetEnderecoPadrao(), "Daniel", "daniel@gmail.com", string.Empty, TelefoneMock.GetTelefonePadrao(), "Senha é obrigatório!" },
            new object[] { EnderecoMock.GetEnderecoPadrao(), string.Empty, "daniel@gmail.com", string.Empty, TelefoneMock.GetTelefonePadrao(), "Nome é obrigatório!" },
        };
        public IEnumerator<object[]> GetEnumerator() =>
            _dados.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>  
            GetEnumerator();
    }
}

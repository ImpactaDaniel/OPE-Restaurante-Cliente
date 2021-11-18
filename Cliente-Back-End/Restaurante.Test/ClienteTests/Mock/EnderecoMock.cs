using Restaurante.Domain.Usuarios.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Restaurante.Test.ClienteTests.Mock
{
    public static class EnderecoMock
    {
        public static Endereco GetEnderecoPadrao() =>
            new Endereco("02998190", "Rua Ângelo Benincori", "City Jaraguá", "114", string.Empty);
    }

    public class CenariosEnderecosInvalidos : IEnumerable<object[]>
    {
        private readonly IList<object[]> _dados = new List<object[]>();
        public CenariosEnderecosInvalidos()
        {
            //string cep, string logradouro, string bairro, string numero, string complemento
            _dados.Add(new object[]
            {
                new Tuple<string, string, string, string, string>(string.Empty, "Rua Ângelo Benincori", "City Jaraguá", "114", string.Empty),
                "CEP precisa ter um valor!"
            });
            _dados.Add(new object[]
            {
                new Tuple<string, string, string, string, string>("aaaaa", "Rua Ângelo Benincori", "City Jaraguá", "114", string.Empty),
                "CEP deve conter somente dígitos!"
            });
            _dados.Add(new object[]
            {
                new Tuple<string, string, string, string, string>("0299819", "Rua Ângelo Benincori", "City Jaraguá", "114", string.Empty),
                "CEP deve conter 8 dígitos!"
            });
            _dados.Add(new object[]
            {
                new Tuple<string, string, string, string, string>("02998190", string.Empty, "City Jaraguá", "114", string.Empty),
                "Logradouro precisa ter um valor!"
            });
            _dados.Add(new object[]
            {
                new Tuple<string, string, string, string, string>("02998190", "Rua Ângelo Benincori", string.Empty, "114", string.Empty),
                "Bairro precisa ter um valor!"
            });
            _dados.Add(new object[]
            {
                new Tuple<string, string, string, string, string>("02998190", "Rua Ângelo Benincori", "City Jaraguá", string.Empty, string.Empty),
                "Número precisa ter um valor!"
            });
        }
        public IEnumerator<object[]> GetEnumerator() =>
            _dados.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            GetEnumerator();
    }
}

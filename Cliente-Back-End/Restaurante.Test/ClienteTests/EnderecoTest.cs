using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Test.ClienteTests.Mock;
using System;
using Xunit;

namespace Restaurante.Test.ClienteTests
{
    public class EnderecoTest
    {
        //Dado cenários com endereços inválidos
        [Theory, ClassData(typeof(CenariosEnderecosInvalidos))]
        public void DeveLancarExcecaoQuandoParametroForInvalido(Tuple<string, string, string, string, string> dadosEndereco, string mensagemEsperada)
        {
            
            //Então deve ser lançada um exceção com a mensagem esperada
            var ex = Assert.Throws<ArgumentException>(() =>
                //Quando tentar criar um novo endereço
                new Endereco(dadosEndereco.Item1, dadosEndereco.Item2, dadosEndereco.Item3, dadosEndereco.Item4, dadosEndereco.Item5)
            );

            Assert.Equal(mensagemEsperada, ex.Message);

        }
    }
}

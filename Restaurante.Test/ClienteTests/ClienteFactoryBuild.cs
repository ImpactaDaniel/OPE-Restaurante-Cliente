using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Test.ClienteTests.Mock;
using System;
using System.Reflection;
using Xunit;

namespace Restaurante.Test.ClienteTests
{
    public class ClienteFactoryBuild
    {
        [Theory, ClassData(typeof(CenariosClientesInvalidosTestes))]
        public void DeveLancarExcecaoQuandoAlgumParametroDoClienteForInvalido(Endereco endereco, string nome, Telefone telefone, string mensagemEsperada)
        {
            //Dado uma factory
            var factory = FactoryMock.GetClienteFactory();

            //Então deve ser lancado uma argument exception
            var ex = Assert.Throws<ArgumentException>(() =>
                //Quando tentar buildar um cliente com um argumento inválido
                factory
                    .ComEndereco(endereco)
                    .ComNome(nome)
                    .ComTelefone(telefone)
                    .Build()
            );
            Assert.Equal(ex.Message, mensagemEsperada);
        }
    }
}

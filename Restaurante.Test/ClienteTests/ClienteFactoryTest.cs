using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Test.ClienteTests.Mock;
using System;
using System.Reflection;
using Xunit;

namespace Restaurante.Test.ClienteTests
{
    public class ClienteFactoryTest
    {
        [Theory, ClassData(typeof(CenariosClientesInvalidosTestes))]
        public void DeveLancarExcecaoQuandoAlgumParametroDoClienteForInvalido(Endereco endereco, string nome, string email, string senha, Telefone telefone, string mensagemEsperada)
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
                    .ComSenha(senha)
                    .ComEmail(email)
                    .Build()
            );
            Assert.Equal(mensagemEsperada, ex.Message);
        }
    }
}

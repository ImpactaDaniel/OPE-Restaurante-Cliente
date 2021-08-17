using Restaurante.Domain.Usuarios.Modelos;
using System;
using Xunit;

namespace Restaurante.Test.ClienteTests
{
    public class TelefoneCtor
    {

        //Dado um ddd ou telefone inválido
        [Theory]
        [InlineData("11", "", "Número de telefone precisa ter um valor!")]
        [InlineData("111", "961537300", "DDD deve conter somente números e conter somente 2 dígitos!")]
        [InlineData("11", "9615373000", "Número do telefone deve conter somente números e ter 8 ou 9 dígitos!")]
        [InlineData("", "9615373000", "DDD precisa ter um valor!")]
        [InlineData("11", "aaaa", "Número do telefone deve conter somente números e ter 8 ou 9 dígitos!")]
        [InlineData("aa", "9615373000", "DDD deve conter somente números e conter somente 2 dígitos!")]
        public void DeveLancarExcecaoQuandoParametroForInvalido(string ddd, string telefone, string mensagemEsperada)
        {
            //então deve ser lançada uma argumentException
            var ex = Assert.Throws<ArgumentException>(() =>
                //Quando é tentado criar um telefone
                new Telefone(ddd, telefone)
            );
            Assert.Equal(mensagemEsperada, ex.Message);
        }
    }
}

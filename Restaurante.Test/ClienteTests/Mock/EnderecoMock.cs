using Restaurante.Domain.Usuarios.Modelos;

namespace Restaurante.Test.ClienteTests.Mock
{
    public static class EnderecoMock
    {
        public static Endereco GetEnderecoPadrao() =>
            new Endereco("02998190", "Rua Ângelo Benincori", "City Jaraguá", "114", string.Empty);
    }
}

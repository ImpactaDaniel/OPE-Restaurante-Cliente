using Restaurante.Domain.Usuarios.Modelos;

namespace Restaurante.Test.ClienteTests.Mock
{
    public static class TelefoneMock
    {
        public static Telefone GetTelefonePadrao() =>
            new Telefone("11", "961537300");
    }
}

using Restaurante.Clientes.Application.Comum;
using Restaurante.Domain.Usuarios.Modelos;

namespace Restaurante.Clientes.Domain.Comum.Modelos.Intefaces
{
    public interface ITokenService
    {
        OutToken GenerateToken(Cliente cliente);
    }
}

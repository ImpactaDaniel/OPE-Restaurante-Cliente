using Restaurante.Domain.Usuarios.Modelos;

namespace Restaurante.Application.Usuarios.Clientes.Requsicoes.Buscar
{
    public class BuscarClienteResposta
    {
        public Cliente Cliente { get; }
        public BuscarClienteResposta(Cliente cliente) =>
            Cliente = cliente;
    }
}

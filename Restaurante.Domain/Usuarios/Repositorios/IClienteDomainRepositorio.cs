using Restaurante.Domain.Usuarios.Modelos;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Domain.Usuarios.Repositorios
{
    public interface IClienteDomainRepositorio : IDomainRepositorio<Cliente>
    {
        Task<Cliente> Buscar(int id, CancellationToken cancellationToken = default);
        Task<bool> Deletar(int id, CancellationToken cancellationToken = default);
        Task<Endereco> BuscarEndereco(int id, CancellationToken cancellationToken = default);
        Task<Telefone> BuscarTelefone(int id, CancellationToken cancellationToken = default);
    }
}

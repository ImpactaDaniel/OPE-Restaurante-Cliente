using Restaurante.Domain.Comum.Modelos;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Domain.Usuarios.Repositorios
{
    public interface IDomainRepositorio<TEntidade> where TEntidade : IEntidade
    {
        Task Salvar(TEntidade entidade, CancellationToken cancellationToken = default);
    }
}

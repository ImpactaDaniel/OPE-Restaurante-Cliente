using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Usuarios.Repositorios;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Infra.Comum.Persistencia
{
    public class RepositorioDados<TDbContext, TEntidade> : IDomainRepositorio<TEntidade>
        where TEntidade : class, IEntidade
        where TDbContext : IDbContext
    {
        protected RepositorioDados(TDbContext db) => Data = db;
        protected TDbContext Data { get; }

        protected IQueryable<TEntidade> All() => Data.Set<TEntidade>();

        public async Task Salvar(TEntidade entidade, CancellationToken cancellationToken = default)
        {
            Data.Update(entidade);
            await Data.SaveChangesAsync(cancellationToken);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Infra.Comum.Persistencia.Interfaces
{
    public interface IDbContext
    {
        DbSet<TEntidade> Set<TEntidade>() where TEntidade : class;
        EntityEntry<TEntidade> Update<TEntidade>(TEntidade entidade) where TEntidade : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

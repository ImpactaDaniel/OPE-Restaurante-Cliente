using System.Collections.Generic;

namespace Restaurante.Clientes.Domain.Comum.Modelos
{
    public class PaginationInfo<TEntity>
    {
        public IEnumerable<TEntity> Entities { get; set; }
        public int Size { get; set; }
    }
}

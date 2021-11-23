using Restaurante.Clientes.Domain.Comum.Modelos;
using Restaurante.Clientes.Domain.Produtos.Modelos;
using Restaurante.Clientes.Domain.Usuarios.Repositorios.Interfaces;
using Restaurante.Domain.Usuarios.Repositorios.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Domain.Produtos.Interfaces
{
    public interface IProdutoDomainRepository : IRepository
    {
        Task<PaginationInfo<Produto>> GetProducts(int size, int page, CancellationToken cancellationToken = default);
        Task<PaginationInfo<Produto>> SearchProducts(int size, int page, string field, string value, CancellationToken cancellationToken = default);
    }
}

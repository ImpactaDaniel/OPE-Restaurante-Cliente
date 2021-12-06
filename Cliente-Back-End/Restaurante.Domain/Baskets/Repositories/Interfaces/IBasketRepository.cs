using System.Threading.Tasks;
using System.Threading;
using Restaurante.Clientes.Domain.Usuarios.Repositorios.Interfaces;
using Restaurante.Clientes.Domain.Baskets.Models;

namespace Restaurante.Clientes.Domain.Baskets.Repositories.Interfaces
{
    public interface IBasketRepository : IRepository
    {
        Task<Basket> GetActiveBasket(int customerId, CancellationToken cancellationToken = default);
        Task AddOrUpdateItem(int customerId, BasketItem item, CancellationToken cancellationToken = default);
        Task RemoveItem(int customerId, int productId, CancellationToken cancellationToken = default);
    }
}

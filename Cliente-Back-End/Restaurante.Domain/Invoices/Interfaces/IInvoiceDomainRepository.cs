using Restaurante.Clientes.Domain.Usuarios.Repositorios.Interfaces;
using Restaurante.Domain.Pedidos.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Domain.Invoices.Interfaces
{
    public interface IInvoiceDomainRepository : IRepository
    {
        Task<IEnumerable<Invoice>> GetByCustomer(int customerId, CancellationToken cancellationToken = default);
        Task<Invoice> GetById(int id, CancellationToken cancellationToken = default);
    }
}

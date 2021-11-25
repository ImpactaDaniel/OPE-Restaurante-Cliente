using Restaurante.Clientes.Domain.Pedidos.Enums;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Application.Hubs.Interfaces
{
    public interface IInvoiceStatusUpdateHub
    {
        Task InvoiceUpdated(string invoiceId, InvoiceStatus invoiceStatus);
    }
}

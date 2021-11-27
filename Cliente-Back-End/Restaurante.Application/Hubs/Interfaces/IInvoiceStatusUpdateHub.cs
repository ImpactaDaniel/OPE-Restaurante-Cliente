using Restaurante.Domain.Pedidos.Models.Enum;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Application.Hubs.Interfaces
{
    public interface IInvoiceStatusUpdateHub
    {
        Task InvoiceUpdated(string invoiceId, InvoiceStatus invoiceStatus);
    }
}

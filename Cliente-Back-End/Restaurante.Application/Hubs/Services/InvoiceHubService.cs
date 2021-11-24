using Microsoft.AspNetCore.SignalR;
using Restaurante.Clientes.Application.Hubs.Interfaces;
using Restaurante.Clientes.Application.Hubs.Services.Intefaces;
using Restaurante.Clientes.Domain.Pedidos.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Application.Hubs.Services
{
    public class InvoiceHubService : IInvoiceHubService
    {
        private readonly IHubContext<InvoiceHub, IInvoiceStatusUpdateHub> _hub;

        private static readonly Dictionary<string, int> _connections = new Dictionary<string, int>();

        public InvoiceHubService(IHubContext<InvoiceHub, IInvoiceStatusUpdateHub> hub)
        {
            _hub = hub;
        }

        public Task AddNewConnection(string connectionId, int customerId)
        {
            _connections.Add(connectionId, customerId);
            return Task.CompletedTask;
        }

        public async Task InvoiceUpdatedNotification(int customerId, string invoiceId, InvoiceStatus invoiceStatus)
        {
            var connections = _connections.Where(c => c.Value == customerId);

            foreach (var connection in connections)
                await _hub.Clients.Client(connection.Key).InvoiceUpdated(invoiceId, invoiceStatus);

        }

        public Task RemoveConnection(string connectionId)
        {
            _connections.Remove(connectionId);
            return Task.CompletedTask;
        }
    }
}

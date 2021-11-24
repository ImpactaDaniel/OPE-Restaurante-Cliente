using Microsoft.AspNetCore.SignalR;
using Restaurante.Clientes.Application.Hubs.Interfaces;
using Restaurante.Clientes.Application.Hubs.Services.Intefaces;
using System;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Application.Hubs
{
    public class InvoiceHub : Hub<IInvoiceStatusUpdateHub>
    {
        private readonly IInvoiceHubService _invoiceHubService;

        public InvoiceHub(IInvoiceHubService invoiceHubService)
        {
            _invoiceHubService = invoiceHubService;
        }
        public Task Connect(string customerId)
        {
            return _invoiceHubService.AddNewConnection(Context.ConnectionId, int.Parse(customerId));
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return _invoiceHubService.RemoveConnection(Context.ConnectionId);
        }
    }
}

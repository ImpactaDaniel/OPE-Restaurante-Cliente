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
        public async Task Connect(string customerId)
        {
            await base.OnConnectedAsync();
            await _invoiceHubService.AddNewConnection(Context.ConnectionId, int.Parse(customerId));
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            await _invoiceHubService.RemoveConnection(Context.ConnectionId);
        }
    }
}

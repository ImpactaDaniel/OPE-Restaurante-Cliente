using Newtonsoft.Json;
using Restaurante.Clientes.Application.Hubs.Services.Intefaces;
using Restaurante.Clientes.Integracoes.EventBus.Interfaces;
using Restaurante.Domain.Pedidos.Models;
using Restaurante.Domain.Pedidos.Models.Enum;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Infra.EventBus
{
    public class InvoiceQueueHandler : IIntegrationEventHandler<InvoiceQueue>
    {
        private readonly IInvoiceHubService _invoiceHubService;
        public InvoiceQueueHandler(IInvoiceHubService invoiceHubService)
        {
            _invoiceHubService = invoiceHubService;
        }

        public async Task Handle(string messageId, InvoiceQueue @event, CancellationToken cancellationToken = default)
        {
            @event.MessageId = Guid.Parse(messageId);
            var invoice = JsonConvert.DeserializeObject<Invoice>(@event.Payload.ToString());

            await _invoiceHubService.InvoiceUpdatedNotification(invoice.CustomerId, invoice.Id.ToString(), invoice.Status);
        }

        public Task HandleError(Exception exception)
        {
            return Task.CompletedTask;
        }
    }
}

using Newtonsoft.Json;
using Restaurante.Clientes.Application.Hubs.Services.Intefaces;
using Restaurante.Clientes.Integracoes.EventBus.Interfaces;
using Restaurante.Integrations;
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

            await _invoiceHubService.InvoiceUpdatedNotification(invoice.Customer.Id, invoice.Id.ToString(), (Domain.Pedidos.Enums.InvoiceStatus)invoice.Status);
        }

        public Task HandleError(Exception exception)
        {
            return Task.CompletedTask;
        }
    }
}

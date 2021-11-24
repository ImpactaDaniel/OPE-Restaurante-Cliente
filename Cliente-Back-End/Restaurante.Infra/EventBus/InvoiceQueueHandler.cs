using Restaurante.Clientes.Integracoes.EventBus.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Infra.EventBus
{
    public class InvoiceQueueHandler : IIntegrationEventHandler<InvoiceQueue>
    {
        public Task Handle(string messageId, InvoiceQueue @event, CancellationToken cancellationToken = default)
        {
            @event.MessageId = System.Guid.Parse(messageId);
            return Task.CompletedTask;
        }

        public Task HandleError(Exception exception)
        {
            return Task.CompletedTask;
        }
    }
}

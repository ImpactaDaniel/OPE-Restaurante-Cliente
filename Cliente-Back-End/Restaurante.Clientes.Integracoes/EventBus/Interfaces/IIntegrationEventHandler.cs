using Restaurante.Clientes.Integracoes.EventBus.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Integracoes.EventBus.Interfaces
{
    public interface IIntegrationEventHandler<in TIntegrationEvent>
        where TIntegrationEvent : IntegrationEvent
    {
        Task Handle(string messageId, TIntegrationEvent @event, CancellationToken cancellationToken = default);

        Task HandleError(Exception exception);
    }
}

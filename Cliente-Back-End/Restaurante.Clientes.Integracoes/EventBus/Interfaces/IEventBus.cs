using Restaurante.Clientes.Integracoes.EventBus.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Integracoes.EventBus.Interfaces
{
    public interface IEventBus
    {
        Task Subscribe<T>(IIntegrationEventHandler<T> handler)
            where T : IntegrationEvent;

        Task UnsubscribeAsync<T>()
            where T : IntegrationEvent;

        Task StartAsync(CancellationToken cancellationToken = default);

        Task StopAsync(CancellationToken cancellationToken = default);
    }
}

using Microsoft.Extensions.Hosting;
using Restaurante.Clientes.Integracoes.EventBus.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.API.HostedServices
{
    public class EventBusHostedService : BackgroundService
    {
        private readonly IEventBus _eventBus;

        public EventBusHostedService(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _eventBus.StartAsync(stoppingToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await _eventBus.StopAsync(cancellationToken);
        }
    }
}

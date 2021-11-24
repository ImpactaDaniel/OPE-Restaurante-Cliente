using Azure.Messaging.ServiceBus;
using Restaurante.Clientes.Integracoes.Config;
using Restaurante.Clientes.Integracoes.EventBus.Interfaces;
using Restaurante.Clientes.Integracoes.EventBus.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Integracoes.EventBus.Implementations
{
    public class AzureEventBus : IEventBus
    {
        private readonly ServiceBusClient _client;
        private static readonly Dictionary<string, ServiceBusProcessor> _processors = new Dictionary<string, ServiceBusProcessor>();
        public AzureEventBus(IntegrationSettings settings)
        {
            _client = new ServiceBusClient(settings.EventBusConnectionString);
        }

        public Task PublishAsync(IntegrationEvent @event)
        {
            throw new System.NotImplementedException();
        }

        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            foreach (var processor in _processors.Values)
                await processor.StartProcessingAsync(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken = default)
        {
            foreach (var processor in _processors.Values)
                await processor.StopProcessingAsync(cancellationToken);
        }

        public void Subscribe<T>(IIntegrationEventHandler<T> handler)
            where T : IntegrationEvent
        {
            var eventName = typeof(T).Name;

            var processor = _client.CreateProcessor(eventName);

            processor.ProcessMessageAsync += async (args) =>
            {
                await args.CompleteMessageAsync(args.Message);
                await handler.Handle(args.Message.MessageId, args.Message.Body.ToObjectFromJson<T>(), args.CancellationToken);
            };

            processor.ProcessErrorAsync += (args) => handler.HandleError(args.Exception);

            _processors.Add(eventName, processor);
        }

        public async Task UnsubscribeAsync<T>() where T : IntegrationEvent
        {
            var eventName = typeof(T).Name;

            var processor = _processors[eventName];

            await processor.StopProcessingAsync();

            await processor.DisposeAsync();

            await _client.DisposeAsync();

            _processors.Remove(eventName);
        }
    }
}

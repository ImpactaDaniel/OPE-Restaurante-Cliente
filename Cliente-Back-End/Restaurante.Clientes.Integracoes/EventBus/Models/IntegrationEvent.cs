using System;

namespace Restaurante.Clientes.Integracoes.EventBus.Models
{
    public abstract class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public Guid MessageId { get; set; }
        public DateTime CreationDate { get; set; }
        public object Payload { get; set; }
    }
}

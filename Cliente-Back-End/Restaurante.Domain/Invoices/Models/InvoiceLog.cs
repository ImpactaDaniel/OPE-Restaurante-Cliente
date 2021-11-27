using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Pedidos.Models.Enum;
using System;

namespace Restaurante.Domain.Pedidos.Models
{
    public class InvoiceLog : Entidade<int>
    {
        public InvoiceLogType Type { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Message { get; set; }
        public Invoice Invoice { get; set; }
    }
}

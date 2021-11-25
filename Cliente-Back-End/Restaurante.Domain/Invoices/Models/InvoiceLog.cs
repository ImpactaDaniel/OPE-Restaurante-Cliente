using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Invoices.Models.Enum;
using System;

namespace Restaurante.Domain.Invoices.Models
{
    public class InvoiceLog : Entidade<int>
    {
        public InvoiceLogType Type { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public Invoice Invoice { get; set; }
    }
}

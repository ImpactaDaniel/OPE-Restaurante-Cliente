using Restaurante.Domain.Pedidos.Models.Enum;
using System.Collections.Generic;

namespace Restaurante.Domain.Pedidos.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public IList<InvoiceLine> Products { get; set; }
        public InvoiceAddress Address { get; set; }
        public InvoiceStatus Status { get; set; }
        public Payment Payment { get; set; }
        public IList<InvoiceLog> Logs { get; set; }
    }
}

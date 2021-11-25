using Restaurante.Domain.Comum.Modelos;
using System.Linq;

namespace Restaurante.Domain.Invoices.Models
{
    public class InvoiceAddress : Entidade<int>
    {
        private InvoiceAddress()
        {
        }

        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string CEP { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}

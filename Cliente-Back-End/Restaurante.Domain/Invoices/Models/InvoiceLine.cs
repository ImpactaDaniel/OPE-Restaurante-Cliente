using Restaurante.Clientes.Domain.Produtos.Modelos;
using Restaurante.Domain.Comum.Modelos;

namespace Restaurante.Domain.Invoices.Models
{
    public class InvoiceLine : Entidade<int>
    {
        public Produto Product { get; set; }
        public int Quantity { get; set; }
        public string Obs { get; set; }
    }
}

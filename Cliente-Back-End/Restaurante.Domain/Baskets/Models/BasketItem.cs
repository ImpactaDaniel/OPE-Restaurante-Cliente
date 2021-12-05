using Restaurante.Clientes.Domain.Produtos.Modelos;

namespace Restaurante.Clientes.Domain.Baskets.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public Produto Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Obs { get; set; }
    }
}

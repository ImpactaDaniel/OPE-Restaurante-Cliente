using System.Collections.Generic;

namespace Restaurante.Clientes.Domain.Produtos.Modelos
{
    public class ProductCategory
    {
        public string Name { get; set; }
        public IEnumerable<Produto> Products { get; set; }
    }
}

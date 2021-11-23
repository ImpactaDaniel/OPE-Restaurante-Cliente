using Restaurante.Domain.Comum.Modelos;
using System;

namespace Restaurante.Clientes.Domain.Produtos.Modelos
{
    public class Produto : Entidade<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Photo Photo { get; set; }
        public ProductCategory Category { get; set; }
        public string Accompaniments { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
    }
}

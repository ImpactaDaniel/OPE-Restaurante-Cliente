using Restaurante.Domain.Usuarios.Modelos;
using System;
using System.Collections.Generic;

namespace Restaurante.Clientes.Domain.Baskets.Models
{
    public class Basket
    {
        public Cliente Customer { get; set; }
        public ICollection<BasketItem> Items { get; set; } = new List<BasketItem>();
        public DateTimeOffset CreatedDate { get; set; }
        public bool Active { get; set; }
        public int CustomerId { get; set; }
    }
}

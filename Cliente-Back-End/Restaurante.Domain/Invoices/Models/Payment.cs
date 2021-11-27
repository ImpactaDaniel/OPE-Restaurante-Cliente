using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Pedidos.Models.Enum;
using System;

namespace Restaurante.Domain.Pedidos.Models
{
    public class Payment : Entidade<int>
    {
        public DateTime PaymentTime { get; set; }
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}

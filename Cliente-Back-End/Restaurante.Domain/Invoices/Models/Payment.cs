using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Invoices.Models.Enum;
using System;

namespace Restaurante.Domain.Invoices.Models
{
    public class Payment : Entidade<int>
    {
        public DateTime PaymentTime { get; set; }
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}

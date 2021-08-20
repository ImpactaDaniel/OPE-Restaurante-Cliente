using System;

namespace Restaurante.Clientes.Application.Comum
{
    public class OutToken
    {
        public string Token { get; }
        public DateTime ValidFrom { get; }
        public DateTime ValidTo { get; }
        public OutToken(string token, DateTime validFrom, DateTime validTo)
        {
            Token = token;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }
    }
}

using System.Collections.Generic;

namespace Restaurante.Domain.Comum.Modelos
{
    public class Resposta
    {
        public Resposta()
        {
            Sucesso = true;
        }
        public Resposta(bool sucesso, IEnumerable<string> erros)
        {
            Sucesso = sucesso;
            Erros = erros;
        }
        public bool Sucesso { get; }
        public IEnumerable<string> Erros { get; }

    }
}

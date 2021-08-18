using System.Collections.Generic;

namespace Restaurante.Domain.Comum.Modelos
{
    public class RespostaConsulta<T> : Resposta
    {
        public T Resposta { get; }

        public RespostaConsulta(T resposta)
        {
            Resposta = resposta;
        }

        public RespostaConsulta(IEnumerable<string> erros) : base(false, erros)
        {
        }
    }
}
